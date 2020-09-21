﻿using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace ClassLibrary
{

public class DibToImage
{


/// /// Get .NET 'Bitmap' object from memory DIB via stream constructor.
/// This should work for most DIBs.
/// /// Pointer to memory DIB, starting with BITMAPINFOHEADER. 
public static Bitmap WithStream( IntPtr dibPtr )
{
BITMAPFILEHEADER fh = new BITMAPFILEHEADER();
Type bmiTyp = typeof(BITMAPINFOHEADER);
BITMAPINFOHEADER bmi = (BITMAPINFOHEADER) Marshal.PtrToStructure( dibPtr, bmiTyp );
if( bmi.biSizeImage == 0 )
bmi.biSizeImage = ((((bmi.biWidth * bmi.biBitCount) + 31) & ~31) >> 3) * Math.Abs( bmi.biHeight );
if( (bmi.biClrUsed == 0) && (bmi.biBitCount < 16) )
bmi.biClrUsed = 1 << bmi.biBitCount;

int fhSize = Marshal.SizeOf( typeof(BITMAPFILEHEADER) );
int dibSize = bmi.biSize + (bmi.biClrUsed * 4) + bmi.biSizeImage; // info + rgb + pixels

fh.Type = new Char[] { 'B', 'M' }; // "BM"
fh.Size = fhSize + dibSize; // final file size
fh.OffBits = fhSize + bmi.biSize + (bmi.biClrUsed * 4); // offset to pixels

byte[] data = new byte[ fh.Size ]; // file-sized byte[] 
RawSerializeInto( fh, data ); // serialize BITMAPFILEHEADER into byte[]
Marshal.Copy( dibPtr, data, fhSize, dibSize ); // mem-copy DIB into byte[]

MemoryStream stream = new MemoryStream( data ); // file-sized stream
Bitmap tmp = new Bitmap( stream ); // 'tmp' is wired to stream (unfortunately)

tmp.Save(stream,System.Drawing.Imaging.ImageFormat.Jpeg);
Bitmap result = new Bitmap( tmp ); // 'result' is a copy (stand-alone)
result.Save(stream,System.Drawing.Imaging.ImageFormat.Jpeg);

tmp.Dispose(); tmp = null;
stream.Close(); stream = null; data = null;
return result;
}



/// /// Get .NET 'Bitmap' object from memory DIB via 'scan0' constructor.
/// This only works for 16..32 pixel-depth RGB DIBs (no color palette)!
/// /// Pointer to memory DIB, starting with BITMAPINFOHEADER. 
public static Bitmap WithScan0( IntPtr dibPtr )
{
Type bmiTyp = typeof(BITMAPINFOHEADER);
BITMAPINFOHEADER bmi = (BITMAPINFOHEADER) Marshal.PtrToStructure( dibPtr, bmiTyp );
if( bmi.biCompression != 0 )
throw new ArgumentException( "Invalid bitmap format (non-RGB)", "BITMAPINFOHEADER.biCompression" );

PixelFormat fmt = PixelFormat.Undefined;
if( bmi.biBitCount == 24 )
fmt = PixelFormat.Format24bppRgb;
else if( bmi.biBitCount == 32 )
fmt = PixelFormat.Format32bppRgb;
else if( bmi.biBitCount == 16 )
fmt = PixelFormat.Format16bppRgb555;
else // we don't support a color palette...
throw new ArgumentException( "Invalid pixel depth (<16-Bits)", "BITMAPINFOHEADER.biBitCount" );

int scan0 = ((int) dibPtr) + bmi.biSize + (bmi.biClrUsed * 4); // pointer to pixels
int stride = (((bmi.biWidth * bmi.biBitCount) + 31) & ~31) >> 3; // bytes/line
if( bmi.biHeight > 0 )
{ // bottom-up
scan0 += stride * (bmi.biHeight - 1);
stride = -stride;
}
Bitmap tmp = new Bitmap( bmi.biWidth, Math.Abs( bmi.biHeight ),
stride, fmt, (IntPtr) scan0 ); // 'tmp' is wired to scan0 (unfortunately)
Bitmap result = new Bitmap( tmp ); // 'result' is a copy (stand-alone)
tmp.Dispose(); tmp = null;
return result;
}





/// /// Get .NET 'Bitmap' object from memory DIB via HBITMAP.
/// Uses many temporary copies [huge memory usage]!
/// /// Pointer to memory DIB, starting with BITMAPINFOHEADER. 
public static Bitmap WithHBitmap( IntPtr dibPtr )
{
Type bmiTyp = typeof(BITMAPINFOHEADER);
BITMAPINFOHEADER bmi = (BITMAPINFOHEADER) Marshal.PtrToStructure( dibPtr, bmiTyp );
if( bmi.biSizeImage == 0 )
bmi.biSizeImage = ((((bmi.biWidth * bmi.biBitCount) + 31) & ~31) >> 3) * Math.Abs( bmi.biHeight );
if( (bmi.biClrUsed == 0) && (bmi.biBitCount < 16) )
bmi.biClrUsed = 1 << bmi.biBitCount;

IntPtr pixPtr = new IntPtr( (int) dibPtr + bmi.biSize + (bmi.biClrUsed * 4) ); // pointer to pixels

IntPtr img = IntPtr.Zero;
int st = GdipCreateBitmapFromGdiDib( dibPtr, pixPtr, ref img );
if( (st != 0) || (img == IntPtr.Zero) )
throw new ArgumentException( "Invalid bitmap for GDI+", "IntPtr dibPtr" );

IntPtr hbitmap;
st = GdipCreateHBITMAPFromBitmap( img, out hbitmap, 0 );
if( (st != 0) || (hbitmap == IntPtr.Zero) )
{
GdipDisposeImage( img );
throw new ArgumentException( "can't get HBITMAP with GDI+", "IntPtr dibPtr" );
}

Bitmap tmp = Image.FromHbitmap( hbitmap ); // 'tmp' is wired to hbitmap (unfortunately)
Bitmap result = new Bitmap( tmp ); // 'result' is a copy (stand-alone)
tmp.Dispose(); tmp = null;
bool ok = DeleteObject( hbitmap ); hbitmap = IntPtr.Zero;
st = GdipDisposeImage( img ); img = IntPtr.Zero;
return result;
}



/// Copy structure into Byte-Array. 
private static void RawSerializeInto( object anything, byte[] datas )
{
int rawsize = Marshal.SizeOf( anything );
if( rawsize > datas.Length )
throw new ArgumentException( " buffer too small ", " byte[] datas " );
GCHandle handle = GCHandle.Alloc( datas, GCHandleType.Pinned );
IntPtr buffer = handle.AddrOfPinnedObject();
Marshal.StructureToPtr( anything, buffer, false );
handle.Free();
}



// GDI imports : read MSDN!

[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi, Pack=1)]
private class BITMAPFILEHEADER
{
[MarshalAs( UnmanagedType.ByValArray, SizeConst=2)] 
public Char[] Type;
public Int32 Size;
public Int16 reserved1;
public Int16 reserved2;
public Int32 OffBits;
}

[StructLayout(LayoutKind.Sequential, Pack=2)]
private class BITMAPINFOHEADER
{
public int biSize;
public int biWidth;
public int biHeight;
public short biPlanes;
public short biBitCount;
public int biCompression;
public int biSizeImage;
public int biXPelsPerMeter;
public int biYPelsPerMeter;
public int biClrUsed;
public int biClrImportant;
}

[DllImport("gdi32.dll", ExactSpelling=true)]
private static extern bool DeleteObject( IntPtr obj );



// GDI+ from GdiplusFlat.h : http://msdn.microsoft.com/library/en-us/gdicpp/gdi+/gdi+reference/flatapi.asp

[DllImport("gdiplus.dll", ExactSpelling=true)]
private static extern int GdipCreateBitmapFromGdiDib( IntPtr bminfo, IntPtr pixdat, ref IntPtr image );
// GpStatus WINGDIPAPI GdipCreateBitmapFromGdiDib( GDIPCONST BITMAPINFO* gdiBitmapInfo, VOID* gdiBitmapData, GpBitmap** bitmap);

[DllImport("gdiplus.dll", ExactSpelling=true)]
private static extern int GdipCreateHBITMAPFromBitmap( IntPtr image, out IntPtr hbitmap, int bkg );
// GpStatus WINGDIPAPI GdipCreateHBITMAPFromBitmap( GpBitmap* bitmap, HBITMAP* hbmReturn, ARGB background);

[DllImport("gdiplus.dll", ExactSpelling=true)]
private static extern int GdipDisposeImage( IntPtr image );

} // class DibToImage

} // namespace


