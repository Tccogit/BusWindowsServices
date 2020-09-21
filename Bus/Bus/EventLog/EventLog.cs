using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.EventLog
{

    public class JEventLog
    {

        public enum EventLogType
        {
            ShutDown_EventType = 1,
            DriverLogin_EventType = 2,
            DriverLogout_EventType = 3,
            SosLogin_EventType = 4,
            SosLogout_EventType = 5,
            MaintenanceLogin_EventType = 6,
            MaintenanceLogout_EventType = 7,
            SHOOTINGGALLERYLogin_EventType = 8,
            SHOOTINGGALLERYLogout_EventType = 9,
            CarWashLogin_EventType = 10,
            CarWashLogout_EventType = 11,
            PassengerControllerLogin_EventType = 12,
            PassengerControllerLogout_EventType = 13,
            DriverCintrollerLogin_EventType = 14,
            DriverCintrollerLogout_EventType = 15,
            DriverManagerLogin_EventType = 16,
            DriverManagerLogout_EventType = 17,
            LineChangerLogin_EventType = 18,
            LineChangerLogout_EventType = 19,
            CardChargerLogin_EventType = 20,
            CardChargerLogout_EventType = 21,
            Bus_OwnerLogin_EventType = 22,
            Bus_OwnerLogout_EventType = 23,
            CardDistrobuterLogin_EventType = 24,
            CardDistrobuterLogout_EventType = 25,
            PassingStation_EventType = 26,
            PassingStationTicket_EventType = 27,
            service_EventType = 28,
            Tarrif_EventType = 29,
            BazrasService_EventType = 30,
            aaaaaa = 31,
            bbbbbb = 32,
            BazrasService_Go_Back_EventType = 33,
            ReaderDetails_EventType = 34
        }

        static bool isStateChanged = false;
        public void EventLogProcess(ClassLibrary.JDataBase Db, ClassLibrary.JMySQLDataBase MySqlDb = null)
        {
            try
            {
                DriversLoginLogoutProcess(Db);
            }
            catch (Exception e)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception(e.Message.ToString() + DateTime.Now.ToLongTimeString()));
            }

            ClassLibrary.JDataBase EventProcessDB = new JDataBase();
            try
            {
                EventProcess(EventProcessDB);
            }
            catch (Exception e)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception(e.Message.ToString() + DateTime.Now.ToLongTimeString()));
            }
            finally
            {
                EventProcessDB.Dispose();
            }


            ClassLibrary.JDataBase EventProcessDB1 = new JDataBase();
            try
            {
                ConsoleLogEvents(EventProcessDB1);
            }
            catch (Exception e)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception(e.Message.ToString() + DateTime.Now.ToLongTimeString()));
            }
            finally
            {
                EventProcessDB1.Dispose();
            }



            ClassLibrary.JDataBase DriverBusServicesProcessDB = new JDataBase();
            try
            {
                DriverBusServicesProcess(DriverBusServicesProcessDB);
            }
            catch (Exception e)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception(e.Message.ToString() + DateTime.Now.ToLongTimeString()));
            }
            finally
            {
                DriverBusServicesProcessDB.Dispose();
            }

        }



        public void DriverBusServicesProcess(ClassLibrary.JDataBase Db)
        {
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            MySqlDb.setQuery(@"SELECT `Code`,`EventType`,`EventDateTime`,`data`,`BusNumber`,`IsProcessed` FROM `eventlog` 
            where `EventType` in (" + EventLogType.service_EventType.GetHashCode() + ") and `IsProcessed` Is NULL Order by `EventDateTime`");
            DataTable Dt = MySqlDb.Query_DataTable();
            try
            {
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            try
                            {
                                byte[] pData = (byte[])Dt.Rows[i]["data"];

                                UInt32 BusNumber = 0;
                                byte[] bBusNumber = new byte[4];
                                Buffer.BlockCopy(pData, 0, bBusNumber, 0, 4);
                                BusNumber = BitConverter.ToUInt32(bBusNumber, 0);

                                UInt32 EndDriverSerialCard = 0;
                                byte[] bEndDriverSerialCard = new byte[4];
                                Buffer.BlockCopy(pData, 4, bEndDriverSerialCard, 0, 4);
                                EndDriverSerialCard = BitConverter.ToUInt32(bEndDriverSerialCard, 0);

                                DateTime EndDATE;
                                byte[] bEndDate = new byte[4];
                                Buffer.BlockCopy(pData, 8, bEndDate, 0, 4);
                                EndDATE = Transaction.JTransactions.ConvertUintToDateTime(BitConverter.ToUInt32(bEndDate, 0));

                                float StartLatGps = 0;
                                byte[] bStartLatGps = new byte[4];
                                Buffer.BlockCopy(pData, 12, bStartLatGps, 0, 4);
                                StartLatGps = BitConverter.ToSingle(bStartLatGps, 0);
                                int TempNewLat = (int)Math.Floor(StartLatGps);
                                if (TempNewLat > 999)
                                    StartLatGps = Transaction.JTransactions.ConvertNMEAToDecimal(StartLatGps);

                                float StartLonGps = 0;
                                byte[] bStartLonGps = new byte[4];
                                Buffer.BlockCopy(pData, 16, bStartLonGps, 0, 4);
                                StartLonGps = BitConverter.ToSingle(bStartLonGps, 0);
                                int TempNewLon = (int)Math.Floor(StartLonGps);
                                if (TempNewLon > 999)
                                    StartLonGps = Transaction.JTransactions.ConvertNMEAToDecimal(StartLonGps);

                                UInt32 EndLineNumber = 0;
                                byte[] bEndLineNumber = new byte[4];
                                Buffer.BlockCopy(pData, 20, bEndLineNumber, 0, 4);
                                EndLineNumber = BitConverter.ToUInt32(bEndLineNumber, 0);

                                UInt32 EndStationCode = 0;
                                byte[] bEndStationCode = new byte[4];
                                Buffer.BlockCopy(pData, 24, bEndStationCode, 0, 4);
                                EndStationCode = BitConverter.ToUInt32(bEndStationCode, 0);

                                UInt32 StartDriverSerialCard = 0;
                                byte[] bStartDriverSerialCard = new byte[4];
                                Buffer.BlockCopy(pData, 28, bStartDriverSerialCard, 0, 4);
                                StartDriverSerialCard = BitConverter.ToUInt32(bStartDriverSerialCard, 0);

                                DateTime StartDATE;
                                byte[] bStartDate = new byte[4];
                                Buffer.BlockCopy(pData, 32, bStartDate, 0, 4);
                                StartDATE = Transaction.JTransactions.ConvertUintToDateTime(BitConverter.ToUInt32(bStartDate, 0));

                                float EndLatGps = 0;
                                byte[] bEndLatGps = new byte[4];
                                Buffer.BlockCopy(pData, 36, bEndLatGps, 0, 4);
                                EndLatGps = BitConverter.ToSingle(bEndLatGps, 0);
                                int TempEndLat = (int)Math.Floor(EndLatGps);
                                if (TempEndLat > 999)
                                    EndLatGps = Transaction.JTransactions.ConvertNMEAToDecimal(EndLatGps);

                                float EndLonGps = 0;
                                byte[] bEndLonGps = new byte[4];
                                Buffer.BlockCopy(pData, 40, bEndLonGps, 0, 4);
                                EndLonGps = BitConverter.ToSingle(bEndLonGps, 0);
                                int TempEndLon = (int)Math.Floor(EndLonGps);
                                if (TempEndLon > 999)
                                    EndLonGps = Transaction.JTransactions.ConvertNMEAToDecimal(EndLonGps);

                                UInt32 StartLineNumber = 0;
                                byte[] bStartLineNumber = new byte[4];
                                Buffer.BlockCopy(pData, 44, bStartLineNumber, 0, 4);
                                StartLineNumber = BitConverter.ToUInt32(bStartLineNumber, 0);

                                UInt32 StartStationCode = 0;
                                byte[] bStartStationCode = new byte[4];
                                Buffer.BlockCopy(pData, 48, bStartStationCode, 0, 4);
                                StartStationCode = BitConverter.ToUInt32(bStartStationCode, 0);

                                UInt32 LineNumber = 0;
                                if (StartLineNumber > 0)
                                    LineNumber = StartLineNumber;
                                else if (EndLineNumber > 0)
                                    LineNumber = EndLineNumber;

                                DataTable dt2;// = Db.Query_DataTable();
                                string[] ParamaName = new string[]
                            {
                                "@BusNumber",
                                "@LineNumber",
                                "@StartLatGps",
                                "@StartLonGps",
                                "@EndLatGps",
                                "@EndLonGps",
                                "@EndDriverSerialCard",
                                "@EventDateTime",
                                "@StartDATE",
                                "@EndDATE"
                            };
                                dt2 = Db.ExecuteProcedure_Query("[dbo].[SP_InsertManualService]", ParamaName,
                                    new string[]
                                {
                                    BusNumber.ToString(),
                                    LineNumber.ToString(),
                                    StartLatGps.ToString(),
                                    StartLonGps.ToString(),
                                    EndLatGps.ToString(),
                                    EndLonGps.ToString(),
                                    EndDriverSerialCard.ToString(),
                                    Dt.Rows[i]["EventDateTime"].ToString(),
                                    StartDATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                    EndDATE.ToString("yyyy-MM-dd HH:mm:ss")
                                });
                                //if (dt2 != null && dt2.Rows.Count > 0)
                                {
                                    MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                    MySqlDb.Query_Execute();
                                }
                            }
                            catch (Exception ex)
                            {
                                MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=2  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                MySqlDb.Query_Execute();
                            }

                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                MySqlDb.Dispose();
            }
        }


        public void ConsoleLogEvents(ClassLibrary.JDataBase Db)
        {
            ClassLibrary.JDataBase DB2 = new JDataBase();
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            MySqlDb.setQuery(@"SELECT `Code`,`EventType`,`EventDateTime`,`data`,`BusNumber`,`IsProcessed` FROM `eventlog` 
            where `EventType` between 1000001 and 1000030 and `IsProcessed` Is NULL Order by `Code`");
            DataTable Dt = MySqlDb.Query_DataTable();
            try
            {
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        try
                        {
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                byte[] pData = (byte[])Dt.Rows[i]["data"];

                                Int32 EventType = Convert.ToInt32(Dt.Rows[i]["EventType"]);

                                UInt32 BusNumber = 0;
                                byte[] bBusNumber = new byte[4];
                                Buffer.BlockCopy(pData, 0, bBusNumber, 0, 4);
                                BusNumber = BitConverter.ToUInt32(bBusNumber, 0);

                                UInt32 CardDriver = 0;
                                byte[] bCardDriver = new byte[4];
                                Buffer.BlockCopy(pData, 4, bCardDriver, 0, 4);
                                CardDriver = BitConverter.ToUInt32(bCardDriver, 0);

                                DB2.setQuery(@"
                            INSERT INTO [dbo].[AUTBusEventRegister]
                                (
                                 [BusCode]
                                ,[DriverPCode]
                                ,[BusEventDetailesCode]
                                ,[StartDate]
                                ,[EndDate]
                                ,[StartTime]
                                ,[EndTime]
                                ,[Status]
                                ,[InsertDate])
                            VALUES
                                (
                                (select code from autbus where busnumber = " + BusNumber.ToString() + @")
                                ,(select top 1 isnull((select top 1 isnull(PCode,0) from cards where RfidNumber = " + CardDriver + @"),0))
                                ," + EventType + @"
                                ,cast('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' as date)
                                ,null
                                ,cast('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' as time)
                                ,null
                                ,0
                                ,getdate());

                                select @@IDENTITY 
                                ");

                                int BusEventRegisterCode = Convert.ToInt32(DB2.Query_DataTable().Rows[0][0]);

                                if (BusEventRegisterCode > 0)
                                {
                                    DB2.setQuery(@"
                            if(" + EventType + @"=1000005 OR " + EventType + @"=1000011)
                            Begin
                                declare @tarif_code int, @status int

                                select @tarif_code = ISNULL(t.Code,0),  @status = ISNULL(t.Status,0)
	                            from AUTTariff t 
	                            inner join AUTShift s on t.ShiftCode = s.Code
	                            where t.BusCode = (select code from autbus where busnumber = " + BusNumber.ToString() + @") 
	                            and '" + Dt.Rows[i]["EventDateTime"].ToString() + @"' between t.Date + cast(s.StartTime as char(8)) 
                                    and t.Date + cast(s.EndTime as char(8))

                                if @tarif_code > 0
                                begin
                                    INSERT INTO [dbo].[AUTBusEventRegisterTarrifCode]
                                        (
                                        [BusEventRegisterCode]
                                        ,[TarrifCode])
                                    VALUES
                                        (
                                        (" + BusEventRegisterCode + @")
                                        ,@tarif_code)

                                    if(@status = 1)
                                    begin
                                        exec [dbo].[SP_TarrifeTaeeidByTarrifCode] @tarif_code = @tarif_code
                                    end
                                end
                            end");
                                    DB2.Query_Execute();
                                }
                                //if (DB2.Query_Execute() >= 0)
                                {
                                    MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                    MySqlDb.Query_Execute();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ClassLibrary.JSystem.Except.AddException(new Exception("NewEventLogError" + ex.Message));
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                MySqlDb.Dispose();
                DB2.Dispose();
            }
        }
        public void EventProcess(ClassLibrary.JDataBase Db)
        {
            ClassLibrary.JDataBase DB2 = new JDataBase();
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                MySqlDb.setQuery(@"SELECT `Code`,`EventType`,`EventDateTime`,`data`,`BusNumber`,`IsProcessed` FROM `eventlog` 
                where `EventType` in (" + EventLogType.Tarrif_EventType.GetHashCode() + @") and `IsProcessed` Is NULL Order by `EventDateTime`");
                DataTable Dt = MySqlDb.Query_DataTable();
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            byte[] pData = (byte[])Dt.Rows[i]["data"];

                            UInt32 EventDetaileCode = 0;
                            byte[] bEventDetaileCode = new byte[4];
                            Buffer.BlockCopy(pData, 0, bEventDetaileCode, 0, 4);
                            EventDetaileCode = BitConverter.ToUInt32(bEventDetaileCode, 0);

                            UInt32 BusNumber = 0;
                            byte[] bBusNumber = new byte[4];
                            Buffer.BlockCopy(pData, 4, bBusNumber, 0, 4);
                            BusNumber = BitConverter.ToUInt32(bBusNumber, 0);
                            if (BusNumber == 9999)
                                BusNumber = 9999;

                            UInt32 LineNumber = 0;
                            byte[] bLineNumber = new byte[4];
                            Buffer.BlockCopy(pData, 8, bLineNumber, 0, 4);
                            LineNumber = BitConverter.ToUInt32(bLineNumber, 0);

                            UInt32 CardDriver = 0;
                            byte[] bCardDriver = new byte[4];
                            Buffer.BlockCopy(pData, 12, bCardDriver, 0, 4);
                            CardDriver = BitConverter.ToUInt32(bCardDriver, 0);

                            float Lat = 0;
                            byte[] bLat = new byte[4];
                            Buffer.BlockCopy(pData, 16, bLat, 0, 4);
                            Lat = BitConverter.ToSingle(bLat, 0);
                            int TempNewLat = (int)Math.Floor(Lat);
                            if (TempNewLat > 999)
                                Lat = Transaction.JTransactions.ConvertNMEAToDecimal(Lat);

                            float Lon = 0;
                            byte[] bLon = new byte[4];
                            Buffer.BlockCopy(pData, 20, bLon, 0, 4);
                            Lon = BitConverter.ToSingle(bLon, 0);
                            int TempNewLon = (int)Math.Floor(Lon);
                            if (TempNewLon > 999)
                                Lon = Transaction.JTransactions.ConvertNMEAToDecimal(Lon);

                            UInt32 StartEnd = 0;
                            byte[] bStartEnd = new byte[1];
                            Buffer.BlockCopy(pData, 24, bStartEnd, 0, 1);
                            StartEnd = bStartEnd[0];//BitConverter.ToBoo(bStartEnd, 0);

                            if (StartEnd == 1)
                            {
                                Db.setQuery(@"INSERT INTO [dbo].[AUTBusEventRegister]
                                               (
                                               [BusCode]
                                               ,[DriverPCode]
                                               ,[BusEventDetailesCode]
                                               ,[StartDate]
                                               ,[EndDate]
                                               ,[StartTime]
                                               ,[EndTime]
                                               ,[Status]
                                               ,[InsertDate])
                                         VALUES
                                               (
                                               (select code from autbus where busnumber = " + BusNumber.ToString() + @")
                                               ,(select isnull((select isnull(PCode,0) from cards where RfidNumber<>0 and RfidNumber = " + CardDriver + @"),0))
                                               ," + EventDetaileCode + @"
                                               ,cast('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' as date)
                                               ,null
                                               ,cast('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' as time)
                                               ,null
                                               ,0
                                               ,getdate())

                                                select @@IDENTITY 
");

                                int BusEventRegisterCode = Convert.ToInt32(Db.Query_DataTable().Rows[0][0]);

                                if (BusEventRegisterCode > 0)
                                {
                                    DB2.setQuery(@"
                                        declare @tarif_code int, @status int

                                        select @tarif_code = ISNULL(t.Code,0),  @status = ISNULL(t.Status,0)
	                                    from AUTTariff t 
	                                    inner join AUTShift s on t.ShiftCode = s.Code
	                                    where t.BusCode = (select code from autbus where busnumber = " + BusNumber.ToString() + @") 
	                                    and '" + Dt.Rows[i]["EventDateTime"].ToString() + @"' between t.Date + cast(s.StartTime as char(8)) 
                                            and t.Date + cast(s.EndTime as char(8))

                                        if @tarif_code > 0
                                        begin
                                            INSERT INTO [dbo].[AUTBusEventRegisterTarrifCode]
                                                   (
                                                    [BusEventRegisterCode]
                                                   ,[TarrifCode])
                                             VALUES
                                                   (
                                                   (" + BusEventRegisterCode + @")
                                                   ,@tarif_code)
                                            if(@status = 1)
                                            begin
                                                exec [dbo].[SP_TarrifeTaeeidByTarrifCode] @tarif_code = @tarif_code
                                            end
                                        end");
                                    DB2.Query_Execute();
                                }
                                MySqlDb.setQuery(@"UPDATE `eventlog` SET IsProcessed=1 WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                MySqlDb.Query_Execute();

                            }
                            else if (StartEnd == 0)
                            {
                                Db.setQuery(@"
                                SELECT Code FROM [dbo].[AUTBusEventRegister] 
                                    where BusCode = (select code from autbus where busnumber = " + BusNumber.ToString() + @") 
                                    and BusEventDetailesCode = " + EventDetaileCode + @" and EndDate is Null");
                                DataTable DT = Db.Query_DataTable();
                                if (DT.Rows.Count == 0)
                                {
                                    MySqlDb.setQuery(@"UPDATE `eventlog` SET IsProcessed=1 WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                    MySqlDb.Query_Execute();
                                }
                                else
                                {
                                    Db.setQuery(@"
                                        declare @BusEventRegisterCode int, @first_tarif_code int, @tarif_code int, @status bit = 0, 
                                        @busnumber float = " + BusNumber.ToString() + @", @StartDateTime DateTime, @EndDateTime datetime = '" + Dt.Rows[i]["EventDateTime"].ToString() + @"'

                                        UPDATE [dbo].[AUTBusEventRegister] Set @BusEventRegisterCode = Code, [EndDate] = cast (@EndDateTime as date) , 
                                            @StartDateTime = StartDate + StartTime,EndTime = cast (@EndDateTime as time) 
                                            where BusCode = (select code from autbus where busnumber = @busnumber) 
                                            and BusEventDetailesCode = " + EventDetaileCode + @" and EndDate is Null

                                        set @first_tarif_code = (select TarrifCode from AUTBusEventRegisterTarrifCode where BusEventRegisterCode = @BusEventRegisterCode) 

                                        DECLARE tariff_cursor CURSOR FOR 
                                        select code, Status from AUTTariff where code <> ISNULL(@first_tarif_code, 0) 
                                        and BusCode = (select code from autbus where BUSNumber = @busnumber) and Date between cast(@StartDateTime as date) and cast(@EndDateTime as date)
                                        and Date + StartTime < @EndDateTime and  Date + EndTime > cast(@StartDateTime as datetime)


                                        OPEN tariff_cursor
                                        FETCH NEXT FROM tariff_cursor 
                                        INTO @tarif_code, @status

                                        WHILE @@FETCH_STATUS = 0
                                        BEGIN

                                        INSERT INTO [dbo].[AUTBusEventRegisterTarrifCode]
                                                (
                                                [BusEventRegisterCode]
                                                ,[TarrifCode])
                                            VALUES
                                                (
                                                @BusEventRegisterCode
                                                ,@tarif_code)

                                            if(@status = 1)
                                            begin
                                                exec [dbo].[SP_TarrifeTaeeidByTarrifCode] @tarif_code = @tarif_code
                                            end

                                            FETCH NEXT FROM tariff_cursor 
                                            INTO @tarif_code, @status
                                        END 
                                        CLOSE tariff_cursor;
                                        DEALLOCATE tariff_cursor;");
                                    Db.Query_Execute();

                                    MySqlDb.setQuery(@"UPDATE `eventlog` SET IsProcessed=1 WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                    MySqlDb.Query_Execute();
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                MySqlDb.Dispose();
                DB2.Dispose();
            }
        }


        public void BusServicesProcess(ClassLibrary.JDataBase Db)
        {
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                MySqlDb.setQuery(@"SELECT `Code`,`EventType`,`EventDateTime`,`data`,`BusNumber`,`IsProcessed` FROM `eventlog` 
            where `EventType` in (" + EventLogType.PassingStation_EventType.GetHashCode() + ") and `IsProcessed` = 1 Order by `EventDateTime`");
                DataTable Dt = MySqlDb.Query_DataTable();
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            byte[] pData = (byte[])Dt.Rows[i]["data"];

                            UInt32 BusNumber = 0;
                            byte[] bBusNumber = new byte[4];
                            Buffer.BlockCopy(pData, 0, bBusNumber, 0, 4);
                            BusNumber = BitConverter.ToUInt32(bBusNumber, 0);

                            UInt32 DriverSerialCard = 0;
                            byte[] bDriverSerialCard = new byte[4];
                            Buffer.BlockCopy(pData, 4, bDriverSerialCard, 0, 4);
                            DriverSerialCard = BitConverter.ToUInt32(bDriverSerialCard, 0);

                            UInt32 StationCode = 0;
                            byte[] bStationCode = new byte[4];
                            Buffer.BlockCopy(pData, 8, bStationCode, 0, 4);
                            StationCode = BitConverter.ToUInt32(bStationCode, 0);

                            Db.setQuery(@"(select case (select top 1 Priority from AUTLineStation where StationCode = " + StationCode + @" and LineCode = 
                                                (select Code from AUTLine where LineNumber = (select LastLineNumber from autbus where BUSNumber = " + BusNumber + @")))
                                                when 1 then 1 else 0 end as FirstStation)");
                            DataTable FirstStation = Db.Query_DataTable();
                            if (FirstStation.Rows[0][0].ToString() == "1")
                            {
                                Db.setQuery(@"INSERT INTO [dbo].[AutBusServices]
                                                   ([Date]
                                                   ,[BusNumber]
                                                   ,[FirstStationCode]
                                                   ,[FirstStationDate]
                                                   ,[LastStationCode]
                                                   ,[LastStationDate]
                                                   ,[DriverCardSerial]
                                                   ,[DriverPersonCode]
                                                   ,[InsertDate]
                                                   ,[FromConsole]
                                                   ,[IsOk]
                                                   ,[Deleted]
                                                   ,[NumOfService]
                                                   ,[EzamBeCode]
                                                   ,[LineNumber])
                                             VALUES
                                                   (cast('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' as date)
                                                   ," + BusNumber.ToString() + @"
                                                   ," + StationCode + @"
                                                   ,'" + Dt.Rows[i]["EventDateTime"].ToString() + @"'
                                                   ,0
                                                   ,null
                                                   ," + DriverSerialCard + @"
                                                   ,ISNULL((select top 1 PCode from Cards where RfidNumber = " + DriverSerialCard + @"),0)
                                                   ,getdate()
                                                   ,1
                                                   ,1
                                                   ,0
                                                   ,1
                                                   ,null
                                                   ,(SELECT LastLineNumber From autbus WHERE BusNumber = " + BusNumber.ToString() + @")
                                                    )");
                                if (Db.Query_Execute() >= 0)
                                {
                                    MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`= 2 WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                    MySqlDb.Query_Execute();
                                }
                            }
                            else
                            {
                                Db.setQuery(@"(select case when 
                                                (select Priority from AUTLineStation where StationCode = " + StationCode + @" and LineCode = 
                                                (select Code from AUTLine where LineNumber = (select LastLineNumber from AUTBus where BUSNumber =  " + BusNumber + @")))
                                                =
                                                (select max(Priority) from AUTLineStation where LineCode = 
                                                (select Code from AUTLine where LineNumber = (select LastLineNumber from AUTBus where BUSNumber =  " + BusNumber + @")))
                                                then 1 else 0 end as LastStation)");
                                DataTable LastStation = Db.Query_DataTable();
                                if (LastStation.Rows[0][0].ToString() == "1")
                                {
                                    Db.setQuery(@"select count(*)RowC from AutBusServices where BusNumber = " + BusNumber + @" and cast(Date as date) = cast('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' as date)");
                                    DataTable LastStationUpdate = Db.Query_DataTable();
                                    if (Convert.ToInt32(LastStationUpdate.Rows[0][0].ToString()) > 0)
                                    {
                                        Db.setQuery(@"update AutBusServices set LastStationCode = " + StationCode + @",LastStationDate = '" + Dt.Rows[i]["EventDateTime"].ToString() + @"'
                                                  where BusNumber = " + BusNumber + @" and cast(Date as date) = cast('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' as date)");
                                        if (Db.Query_Execute() >= 0)
                                        {
                                            MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                            MySqlDb.Query_Execute();
                                        }
                                    }
                                }
                                else
                                {
                                    MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                    MySqlDb.Query_Execute();
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                MySqlDb.Dispose();
            }
        }


        public static void BazrasServicesProcess(ClassLibrary.JDataBase Db)
        {
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                MySqlDb.setQuery(@"SELECT `Code`,`EventType`,`EventDateTime`,`data`,`BusNumber`,`IsProcessed` FROM `eventlog` 
                where `EventType` in (" + EventLogType.BazrasService_EventType.GetHashCode() + @") 
                and `IsProcessed` Is NULL  Order by `EventDateTime` DESC LIMIT 200");
                DataTable Dt = MySqlDb.Query_DataTable();
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            try
                            {
                                byte[] pData = (byte[])Dt.Rows[i]["data"];

                                UInt32 BazrasCode = 0;
                                byte[] bBazrasCode = new byte[4];
                                Buffer.BlockCopy(pData, 0, bBazrasCode, 0, 4);
                                BazrasCode = BitConverter.ToUInt32(bBazrasCode, 0);


                                Int32 BusNumber = 0;
                                byte[] bBusNumber = new byte[4];
                                Buffer.BlockCopy(pData, 4, bBusNumber, 0, 4);
                                BusNumber = BitConverter.ToInt32(bBusNumber, 0);

                                DateTime DateTime;
                                byte[] bDateTime = new byte[4];
                                Buffer.BlockCopy(pData, 8, bDateTime, 0, 4);
                                DateTime = Transaction.JTransactions.ConvertUintToDateTime(BitConverter.ToUInt32(bDateTime, 0));

                                UInt32 DriverSerialCard = 0;
                                byte[] bDriverSerialCard = new byte[4];
                                Buffer.BlockCopy(pData, 12, bDriverSerialCard, 0, 4);
                                DriverSerialCard = BitConverter.ToUInt32(bDriverSerialCard, 0);

                                Int32 LineNumber = 0;
                                byte[] bLineNumber = new byte[4];
                                Buffer.BlockCopy(pData, 16, bLineNumber, 0, 4);
                                LineNumber = BitConverter.ToInt32(bLineNumber, 0);

                                DateTime MoveDate;
                                byte[] bMoveDate = new byte[4];
                                Buffer.BlockCopy(pData, 20, bMoveDate, 0, 4);
                                MoveDate = Transaction.JTransactions.ConvertUintToDateTime(BitConverter.ToUInt32(bMoveDate, 0));

                                Bazras.JBazRasService B = new Bazras.JBazRasService();
                                B.BazrasCode = BazrasCode;
                                B.BusNumber = BusNumber;
                                B.DateCard = DateTime;
                                B.DriverCode = DriverSerialCard;
                                B.LineNumber = LineNumber;
                                B.MoveDate = MoveDate;
                                B.BazrasDevice = Convert.ToInt16(Dt.Rows[i]["BusNumber"]);

                                int BazrasInsertCode = B.Insert();
                                if (BazrasInsertCode > 0 )
                                {
                                    MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                    MySqlDb.Query_Execute();

                                    Db.setQuery(@"INSERT INTO [dbo].[AutConsoleMessage]
                                           ([BusNumber]
                                           ,[MessageText]
                                           ,[InsertDate])
                                     VALUES
                                           (" + BusNumber.ToString() + @"
                                           ,N'زمان حرکت شما در اتوبوس " + BusNumber + " ساعت " + MoveDate.Hour + ":" + MoveDate.Minute + " می باشد.',getdate())");
                                    Db.Query_Execute();

                                    if (DriverSerialCard > 0 && DateTime> DateTime.Now.AddMinutes(-10) && DateTime < DateTime.Now.AddMinutes(1))
                                    {
                                        Db.setQuery("select  Mobile from " + JMainFrame.Server01 + @"erp_tabrizbus.dbo.clsPersonAddress where PCode in(select PCode from Cards where RfidNumber=" + DriverSerialCard + ") and len(Mobile)>=10");
                                        DataTable DT = Db.Query_DataTable();
                                        if (DT.Rows.Count == 1)
                                        {
                                            JSMSSend SmSSend = new JSMSSend();
                                            SmSSend.ClassName = "BusManagment.EventLog.JEventLog.BazrasServicesProcess";
                                            SmSSend.Description = "";
                                            SmSSend.Mobile = DT.Rows[0]["Mobile"].ToString();
                                            SmSSend.ObjectCode = 0;
                                            SmSSend.PersonCode = 0;
                                            SmSSend.Project = "BusManagment";
                                            SmSSend.RegDate = JDateTime.Now();
                                            SmSSend.Text = "زمان حرکت شما در اتوبوس " + BusNumber + " ساعت " + MoveDate.Hour + ":" + MoveDate.Minute + " می باشد.";
                                            SmSSend.SendDevice = 1;
                                            //SmSSend.ExpireDate = DateTime.Now.AddMinutes(+15);
                                            SmSSend.Insert();
                                        }
                                    }

                                }
                                else
                                {
                                    MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=2  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                    MySqlDb.Query_Execute();
                                }
                            }
                            catch
                            {
                                MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=2  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                MySqlDb.Query_Execute();
                            }

                        }
                    }
                }
            }

            finally
            {
                MySqlDb.Dispose();
            }
        }

        public static void ReaderDetailsProcess(ClassLibrary.JDataBase Db)
        {
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                MySqlDb.setQuery(@"SELECT `Code`,`EventType`,`EventDateTime`,`data`,`BusNumber`,`IsProcessed` FROM `eventlog` 
                where `EventType` in (" + EventLogType.ReaderDetails_EventType.GetHashCode() + @") 
                and `IsProcessed` Is NULL  Order by `EventDateTime` DESC LIMIT 200");
                DataTable Dt = MySqlDb.Query_DataTable();
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            try
                            {
                                byte[] pData = (byte[])Dt.Rows[i]["data"];

                                Int64 MicID = 0;
                                byte[] bMicID = new byte[8];
                                Buffer.BlockCopy(pData, 0, bMicID, 0, 8);
                                MicID = BitConverter.ToInt64(bMicID, 0);
                                
                                string ReaderVersion = "";
                                byte[] bReaderVersion = new byte[4];
                                Buffer.BlockCopy(pData, 8, bReaderVersion, 0, 4);
                                ReaderVersion = bReaderVersion[0].ToString() + bReaderVersion[1].ToString() + bReaderVersion[2].ToString();
                                int rdv;
                                int.TryParse(ReaderVersion, out  rdv);

                                string ModuleVersion = "";
                                byte[] bModuleVersion = new byte[4];
                                Buffer.BlockCopy(pData, 12, bModuleVersion, 0, 4);
                                ModuleVersion = bModuleVersion[0].ToString() + bModuleVersion[1].ToString() + bModuleVersion[2].ToString();
                                int mv;
                                int.TryParse(ModuleVersion, out mv);

                                UInt32 SamSerial = 0;
                                byte[] bSamSerial = new byte[4];
                                Buffer.BlockCopy(pData, 16, bSamSerial, 0, 4);
                                SamSerial = BitConverter.ToUInt32(bSamSerial, 0);

                                int BusNumber = 0;
                                byte[] bBusNumber = new byte[4];
                                Buffer.BlockCopy(pData, 20, bBusNumber, 0, 4);
                                BusNumber = BitConverter.ToInt16(bBusNumber, 0);

                                int ReaderID = 0;
                                byte[] bReaderID = new byte[4];
                                Buffer.BlockCopy(pData, 24, bReaderID, 0, 1);
                                ReaderID = BitConverter.ToInt16(bReaderID, 0);
                                if (BusNumber >999  && BusNumber < 10000 && ReaderID > 0 && ReaderID < 10 && SamSerial > 0)
                                {
                                    try
                                    {
                                        Reader.JReader R = new Reader.JReader();
                                        R.MicID = MicID;
                                        R.ReaderVersion = rdv;
                                        R.ModuleVersion = mv;
                                        R.SamSerial = SamSerial;
                                        R.BusNumber = BusNumber;
                                        R.ReaderId = ReaderID;
                                        R.VersionDate = DateTime.Now;
                                        if(R.Insert()>=1)
                                        {
                                            MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                            MySqlDb.Query_Execute();
                                        }
                                        else
                                        {
                                            MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=2  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                            MySqlDb.Query_Execute();
                                        }

                                    }
                                    catch
                                    {

                                    }
                                }
                                else
                                {
                                    MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=6  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                    MySqlDb.Query_Execute();
                                }
                            
                            }
                            catch
                            {
                                MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=2  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                MySqlDb.Query_Execute();
                            }

                        }
                    }
                }
            }

            finally
            {
                MySqlDb.Dispose();
            }
        }

        public static void BazrasServicesGoBackProcess(ClassLibrary.JDataBase Db)
        {
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                MySqlDb.setQuery(@"SELECT `Code`,`EventType`,`EventDateTime`,`data`,`BusNumber`,`IsProcessed` FROM `eventlog` 
                where `EventType` in (" + EventLogType.BazrasService_Go_Back_EventType.GetHashCode()
                + @") and `IsProcessed` Is NULL Order by `EventDateTime` DESC LIMIT 200");
                DataTable Dt = MySqlDb.Query_DataTable();
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            try
                            {
                                byte[] pData = (byte[])Dt.Rows[i]["data"];

                                UInt32 BazrasCode = 0;
                                byte[] bBazrasCode = new byte[4];
                                Buffer.BlockCopy(pData, 0, bBazrasCode, 0, 4);
                                BazrasCode = BitConverter.ToUInt32(bBazrasCode, 0);


                                Int32 BusNumber = 0;
                                byte[] bBusNumber = new byte[4];
                                Buffer.BlockCopy(pData, 4, bBusNumber, 0, 4);
                                BusNumber = BitConverter.ToInt32(bBusNumber, 0);

                                DateTime DateTime;
                                byte[] bDateTime = new byte[4];
                                Buffer.BlockCopy(pData, 8, bDateTime, 0, 4);
                                DateTime = Transaction.JTransactions.ConvertUintToDateTime(BitConverter.ToUInt32(bDateTime, 0));

                                UInt32 DriverSerialCard = 0;
                                byte[] bDriverSerialCard = new byte[4];
                                Buffer.BlockCopy(pData, 12, bDriverSerialCard, 0, 4);
                                DriverSerialCard = BitConverter.ToUInt32(bDriverSerialCard, 0);

                                Int32 LineNumber = 0;
                                byte[] bLineNumber = new byte[4];
                                Buffer.BlockCopy(pData, 16, bLineNumber, 0, 4);
                                LineNumber = BitConverter.ToInt32(bLineNumber, 0);

                                DateTime MoveDate;
                                byte[] bMoveDate = new byte[4];
                                Buffer.BlockCopy(pData, 20, bMoveDate, 0, 4);
                                MoveDate = Transaction.JTransactions.ConvertUintToDateTime(BitConverter.ToUInt32(bMoveDate, 0));

                                DateTime Date1;
                                byte[] bDate1 = new byte[4];
                                Buffer.BlockCopy(pData, 24, bDate1, 0, 4);
                                Date1 = Transaction.JTransactions.ConvertUintToDateTime(BitConverter.ToUInt32(bDate1, 0));

                                DateTime Date2;
                                byte[] bDate2 = new byte[4];
                                Buffer.BlockCopy(pData, 28, bDate2, 0, 4);
                                Date2 = Transaction.JTransactions.ConvertUintToDateTime(BitConverter.ToUInt32(bDate2, 0));

                                DateTime Date3;
                                byte[] bDate3 = new byte[4];
                                Buffer.BlockCopy(pData, 32, bDate3, 0, 4);
                                Date3 = Transaction.JTransactions.ConvertUintToDateTime(BitConverter.ToUInt32(bDate3, 0));

                                Bazras.JBazRasService B = new Bazras.JBazRasService();
                                B.BazrasCode = BazrasCode;
                                B.BusNumber = BusNumber;
                                B.DateCard = DateTime;
                                B.DriverCode = DriverSerialCard;
                                B.LineNumber = LineNumber;
                                B.MoveDate = MoveDate;
                                int BazrasInsertCode = B.Find();
                                if (BazrasInsertCode > 0)
                                {
                                    Db.setQuery(@"UPDATE AUTBazRasService set Date1='"
                                        + Date1.ToString("yyyy-MM-dd HH:mm:ss")
                                        + "' , Date2='"
                                        + Date2.ToString("yyyy-MM-dd HH:mm:ss")
                                        + "' , Date3='"
                                        + Date3.ToString("yyyy-MM-dd HH:mm:ss")
                                        + "' where Code=" + BazrasInsertCode);
                                    Db.Query_Execute();
                                    MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                    MySqlDb.Query_Execute();
                                }
                                else
                                {
                                    MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                    MySqlDb.Query_Execute();
                                }
                            }
                            catch
                            {
                                MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                MySqlDb.Query_Execute();
                            }

                        }
                    }
                }
            }

            finally
            {
                MySqlDb.Dispose();
            }
        }

        public static void BusPassingStationProcess(ClassLibrary.JDataBase Db)
        {
            //عدم استفاده از این تابع دیتا حذف می شود
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            MySqlDb.setQuery(@"DELETE FROM `eventlog` 
            where `EventType` in (" + EventLogType.PassingStation_EventType.GetHashCode() + "," + EventLogType.PassingStationTicket_EventType.GetHashCode() + ")");
            MySqlDb.Query_Execute();
            MySqlDb.Dispose();
            return;

            try
            {
                MySqlDb.setQuery(@"SELECT `Code`,`EventType`,`EventDateTime`,`data`,`BusNumber`,`IsProcessed` FROM `eventlog` 
            where `EventType` in (" + EventLogType.PassingStation_EventType.GetHashCode() + "," + EventLogType.PassingStationTicket_EventType.GetHashCode() + ") and `IsProcessed` Is NULL Order by `Code` desc");
                DataTable Dt = MySqlDb.Query_DataTable();
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            byte[] pData = (byte[])Dt.Rows[i]["data"];

                            UInt32 BusNumber = 0;
                            byte[] bBusNumber = new byte[4];
                            Buffer.BlockCopy(pData, 0, bBusNumber, 0, 4);
                            BusNumber = BitConverter.ToUInt32(bBusNumber, 0);

                            UInt32 DriverSerialCard = 0;
                            byte[] bDriverSerialCard = new byte[4];
                            Buffer.BlockCopy(pData, 4, bDriverSerialCard, 0, 4);
                            DriverSerialCard = BitConverter.ToUInt32(bDriverSerialCard, 0);

                            UInt32 StationCode = 0;
                            byte[] bStationCode = new byte[4];
                            Buffer.BlockCopy(pData, 8, bStationCode, 0, 4);
                            StationCode = BitConverter.ToUInt32(bStationCode, 0);

                            if (Dt.Rows[i]["EventType"].ToString() == EventLogType.PassingStation_EventType.GetHashCode().ToString())
                            {
                                Db.setQuery(@"INSERT INTO [dbo].[AutBusPassingStations]
                                               ([EventDate]
                                               ,[BusNumber]
                                               ,[StationCode]
                                               ,[DriverCardSerial]
                                               ,[DriverPersonCode]
                                               ,[FirstStation]
                                               ,[LastStation]
                                               ,[InsertDate])
                                         VALUES
                                               ('" + Dt.Rows[i]["EventDateTime"].ToString() + @"'
                                               ," + BusNumber.ToString() + @"
                                               ," + StationCode + @"
                                               ," + DriverSerialCard + @"
                                               ,ISNULL((select top 1 PCode from Cards where RfidNumber = " + DriverSerialCard + @"),0)
                                               ,(select case 
                                                (select top 1 Priority from AUTLineStation where StationCode = " + StationCode + @" and LineCode = 
                                                (select Code from AUTLine where LineNumber = (select LastLineNumber from AUTBus where BUSNumber = " + BusNumber.ToString() + @")))
                                                when 1 then 1 else 0 end as FirstStation)
                                               ,(select case when 
                                                (select Priority from AUTLineStation where StationCode = " + StationCode + @" and LineCode = 
                                                (select Code from AUTLine where LineNumber = (select LastLineNumber from AUTBus where BUSNumber =  " + BusNumber.ToString() + @")))
                                                =
                                                (select max(Priority) from AUTLineStation where LineCode = 
                                                (select Code from AUTLine where LineNumber = (select LastLineNumber from AUTBus where BUSNumber =  " + BusNumber.ToString() + @")))
                                                then 1 else 0 end as LastStation)
                                               ,getdate())");
                            }
                            else if (Dt.Rows[i]["EventType"].ToString() == EventLogType.PassingStationTicket_EventType.GetHashCode().ToString())
                            {

                                UInt32 TicketCount = 0;
                                byte[] bTicketCount = new byte[4];
                                Buffer.BlockCopy(pData, 12, bTicketCount, 0, 4);
                                TicketCount = BitConverter.ToUInt32(bTicketCount, 0);

                                if (TicketCount > 32769) TicketCount = 0;

                                Db.setQuery(@"INSERT INTO [dbo].[AutBusPassingStationTicket]
                                               ([EventDate]
                                               ,[BusNumber]
                                               ,[StationCode]
                                               ,[DriverCardSerial]
                                               ,[DriverPersonCode]
                                               ,[TicketCount]
                                               ,[InsertDate])
                                         VALUES
                                               ('" + Dt.Rows[i]["EventDateTime"].ToString() + @"'
                                               ," + BusNumber.ToString() + @"
                                               ," + StationCode + @"
                                               ," + DriverSerialCard + @"
                                               ,ISNULL((select top 1 PCode from Cards where RfidNumber = " + DriverSerialCard + @"),0)
                                               ," + TicketCount + @"
                                               ,getdate())");

                            }
                            if (Db.Query_Execute() >= 0)
                            {
                                MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                MySqlDb.Query_Execute();
                            }
                        }
                    }
                }
            }
            finally
            {
                MySqlDb.Dispose();
            }
        }
        public static bool SaveDriverLoginLogout(string eventType, string eventDatetime, uint busNumber, long driverSerialCard, JDataBase Db = null)
        {
            JDataBase tempDB = Db == null ? new JDataBase() : Db;
            try
            {
                if (eventType.ToString() == EventLogType.DriverLogin_EventType.GetHashCode().ToString())
                {
                    Db.setQuery(@"select top 1 * from  AUTDriversLoginLogout 
                                    where BusNumber = " + busNumber.ToString() + @" and [DriverCardSerial] = " + driverSerialCard + @" 
                                    and Date = cast ('" + eventDatetime.ToString() + @"' as date) 
                                    and LogoutTime is not null and LogoutTime>cast ('" + eventDatetime.ToString() + @"' as time) and [LoginTime] is null");
                    DataTable DT = Db.Query_DataTable();

                    if (DT != null && DT.Rows.Count == 1)
                    {
                        Db.setQuery(@"UPDATE [AUTDriversLoginLogout] 
                                    Set [LoginTime] = cast ('" + eventDatetime.ToString() + @"' as time)
                                    where BusNumber = " + busNumber.ToString() + @" and [DriverCardSerial] = " + driverSerialCard + @" 
                                    and Date = cast ('" + eventDatetime.ToString() + @"' as date) and [LogoutTime] is not null 
                                    and LogoutTime>cast ('" + eventDatetime.ToString() + @"' as time) and logintime is null");
                        Db.Query_Execute();
                        Db.setQuery("Update AUTBus Set LastDriverPersonCode=(select PCode from Cards where RfidNumber = " + driverSerialCard + ") where BUSNumber=" + busNumber.ToString());
                        Db.Query_Execute();
                    }
                    else
                    {
                        Db.setQuery(@"INSERT INTO [dbo].[AUTDriversLoginLogout]
                                        ([Date]
                                        ,[BusNumber]
                                        ,[DriverCardSerial]
                                        ,[DriverPersonCode]
                                        ,[LoginTime]
                                        ,[LogoutTime]
                                        ,[InsertDate])
                                    VALUES
                                        (cast ('" + eventDatetime.ToString() + @"' as date)
                                        ," + busNumber.ToString() + @"
                                        ," + driverSerialCard + @"
                                        ,ISNULL((select top 1 PCode from Cards where RfidNumber = " + driverSerialCard + @"),0)
                                        ,cast ('" + eventDatetime.ToString() + @"' as time)
                                        ,NULL
                                        ,getdate())");
                        Db.Query_Execute();
                        Db.setQuery("Update AUTBus Set LastDriverPersonCode=(select PCode from Cards where RfidNumber = " + driverSerialCard + ") where BUSNumber=" + busNumber.ToString());
                        Db.Query_Execute();
                    }
                }
                else if (eventType.ToString() == EventLogType.DriverLogout_EventType.GetHashCode().ToString())
                {
                    Db.setQuery(@"select top 1 * from  AUTDriversLoginLogout 
                                    where BusNumber = " + busNumber.ToString() + @" and [DriverCardSerial] = " + driverSerialCard + @" 
                                    and Date = cast ('" + eventDatetime.ToString() + @"' as date) 
                                    and [LogoutTime] is null and LoginTime is not null and LoginTime < cast ('" + eventDatetime.ToString() + @"' as time)");
                    DataTable DT = Db.Query_DataTable();

                    if (DT != null && DT.Rows.Count == 1)
                    {

                        Db.setQuery(@"UPDATE AUTDriversLoginLogout 
                                    Set [LogoutTime] = cast ('" + eventDatetime.ToString() + @"' as time)
                                    where BusNumber = " + busNumber.ToString() + @" and [DriverCardSerial] = " + driverSerialCard + @" 
                                    and Date = cast ('" + eventDatetime.ToString() + @"' as date) and [LogoutTime] is null
                                    and LoginTime is not null and LoginTime < cast ('" + eventDatetime.ToString() + @"' as time)");
                        Db.Query_Execute();
                        Db.setQuery("Update AUTBus Set LastDriverPersonCode=0 where BUSNumber=" + busNumber.ToString());
                        Db.Query_Execute();
                    }
                    else
                    {
                        Db.setQuery(@"INSERT INTO AUTDriversLoginLogout
                                        ([Date]
                                        ,[BusNumber]
                                        ,[DriverCardSerial]
                                        ,[DriverPersonCode]
                                        ,[LoginTime]
                                        ,[LogoutTime]
                                        ,[InsertDate])
                                    VALUES
                                        (cast ('" + eventDatetime.ToString() + @"' as date)
                                        ," + busNumber.ToString() + @"
                                        ," + driverSerialCard + @"
                                        ,ISNULL((select top 1 PCode from Cards where RfidNumber = " + driverSerialCard + @"),0)
                                        ,NULL
                                        ,cast ('" + eventDatetime.ToString() + @"' as time)
                                        ,getdate())");
                        Db.Query_Execute();
                        Db.setQuery("Update AUTBus Set LastDriverPersonCode=0 where BUSNumber=" + busNumber.ToString());
                        Db.Query_Execute();
                    }
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                if (Db == null)
                    tempDB.Dispose();
            }
            return true;
        }
        public void DriversLoginLogoutProcess(ClassLibrary.JDataBase Db)
        {
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                MySqlDb.setQuery(@"SELECT `Code`,`EventType`,`EventDateTime`,`data`,`BusNumber`,`IsProcessed` FROM `eventlog` 
                    where `EventType` in (" + EventLogType.DriverLogin_EventType.GetHashCode() + "," + EventLogType.DriverLogout_EventType.GetHashCode() + ") and `IsProcessed` Is NULL Order by `Code`");
                DataTable Dt = MySqlDb.Query_DataTable();
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            Db.setQuery(@"
                            IF(EXISTS(SELECT * FROM AUTDriversLoginLogout 
                                WHERE [Date] = CAST('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' AS DATE) AND [BusNumber] = " + Dt.Rows[i]["BusNumber"].ToString() + @" 
                                AND (
                                        (CAST('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' AS TIME) > [LoginTime] AND CAST('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' AS TIME) < [LogoutTime])
                                        OR
                                        CAST('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' AS TIME) = [LoginTime] 
                                        OR 
                                        CAST('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' AS TIME) = [LogoutTime]
                                    )
                              )
                              )
                            SELECT 1");
                            DataTable dt2 = Db.Query_DataTable();
                            if (dt2 != null && dt2.Rows.Count > 0)
                            {
                                MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                MySqlDb.Query_Execute();
                                continue;
                            }
                            //else
                            byte[] pData = (byte[])Dt.Rows[i]["data"];

                            UInt32 BusNumber = 0;
                            byte[] bBusNumber = new byte[4];
                            Buffer.BlockCopy(pData, 0, bBusNumber, 0, 4);
                            BusNumber = BitConverter.ToUInt32(bBusNumber, 0);

                            UInt32 DriverSerialCard = 0;
                            byte[] bDriverSerialCard = new byte[4];
                            Buffer.BlockCopy(pData, 4, bDriverSerialCard, 0, 4);
                            DriverSerialCard = BitConverter.ToUInt32(bDriverSerialCard, 0);
                            SaveDriverLoginLogout(Dt.Rows[i]["EventType"].ToString(), Dt.Rows[i]["EventDateTime"].ToString(), BusNumber, DriverSerialCard, Db);
                            //if (Db.Query_Execute() >= 0)
                            {
                                MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1  WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                                MySqlDb.Query_Execute();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                MySqlDb.Dispose();
            }
        }


        public void InsertIntoAUTConsoleQuerySendStatus(ClassLibrary.JDataBase Db)
        {
            return;
            // روش بهینه نیست در صورت بهنه شدن باید اجرا شود
            try
            {
                Db.setQuery(@"
                    IF OBJECT_ID('tempdb..#T') IS NOT NULL DROP Table #T
                    select *  into #T from
                    (
	                    select a.BusNUmber, q.Code, q.QueryText, q.DataBaseName, 0 Status, GETDATE() InsertDate from " + JMainFrame.Server01 + @"erp_tabrizbus.dbo.AUTConsoleQueryAuto q inner join AUTBus a on q.BusCode=a.Code and q.LineNumber=a.LastLineNumber where BusCode is not null and LineNumber is not null and a.IsValid = 1 and a.Active=1
	                    union
	                    select a.BusNUmber, q.Code, q.QueryText, q.DataBaseName, 0 Status, GETDATE() InsertDate from " + JMainFrame.Server01 + @"erp_tabrizbus.dbo.AUTConsoleQueryAuto q inner join AUTBus a on q.LineNumber=a.LastLineNumber where BusCode is null and LineNumber is not null and a.IsValid = 1 and a.Active=1
	                    union
	                    select a.BusNUmber, q.Code, q.QueryText, q.DataBaseName, 0 Status, GETDATE() InsertDate from " + JMainFrame.Server01 + @"erp_tabrizbus.dbo.AUTConsoleQueryAuto q inner join AUTBus a on q.BusCode=a.Code  where BusCode is not null and LineNumber is null and a.IsValid = 1 and a.Active=1
	                    union
	                    select a.BusNUmber, q.Code, q.QueryText, q.DataBaseName, 0 Status, GETDATE() InsertDate from " + JMainFrame.Server01 + @"erp_tabrizbus.dbo.AUTConsoleQueryAuto q inner join AUTBus a on 1=1 where BusCode is null and LineNumber is null and a.IsValid = 1 and a.Active=1
                    ) a order by a.Code
                    insert into AUTConsoleQuerySendStatus(BusNumber,QueryCode,QueryText,DataBaseName,Status,InsertDate)
                    select * from #T t where Not Exists (select 1 from AUTConsoleQuerySendStatus where QueryCode=t.Code and BusNumber=t.BUSNumber) order by t.Code");
                Db.Query_Execute();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception("1EventLogError" + ex.Message));
            }

        }
        public void InsertIntoGetQuery(ClassLibrary.JDataBase Db, ClassLibrary.JMySQLDataBase mysqlDB = null)
        {
            try
            {
                int MySqlMaxCodeInt = 0;
                int SqlMaxCodeInt = 0;
                DataTable MySqlMaxCode = null;
                do
                {
                    mysqlDB.setQuery(@"SELECT  IFNULL(max( `Code` ),0) AS max_value FROM `GetQuery`");
                    MySqlMaxCode = mysqlDB.Query_DataTable();
                    System.Threading.Thread.Sleep(500);
                }
                while (MySqlMaxCode == null);
                MySqlMaxCodeInt = Convert.ToInt32(MySqlMaxCode.Rows[0]["max_value"].ToString());
                Db.setQuery(@"SELECT Code
                                ,BUSNumber
                                ,QueryText
                                ,DataBaseName
                            FROM AUTConsoleQuerySendStatus
                            WHERE status=0 and Code > " + MySqlMaxCodeInt);
                DataTable Dt = Db.Query_DataTable();
                string MySqlQuery = "";
                string SqlQuery = "";
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    SqlMaxCodeInt = Convert.ToInt32(Dt.Rows[Dt.Rows.Count - 1]["Code"].ToString());
                    SqlQuery = "UPDATE AUTConsoleQuerySendStatus SET Status = 1 WHERE CODE BETWEEN " + (MySqlMaxCodeInt + 1) + " AND " + SqlMaxCodeInt;
                    MySqlQuery += @"INSERT INTO `GetQuery`(`Code`, `BusSerial`, `State`, `Query`, `DataBase`) VALUES ";
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        MySqlMaxCodeInt++;
                        MySqlQuery += @" (" + Dt.Rows[i]["Code"].ToString() + @" , " + Dt.Rows[i]["BUSNumber"].ToString() + @" , 0, """
                            + Dt.Rows[i]["QueryText"].ToString().Replace("\"", "\"\"") + @""",""" + Dt.Rows[i]["DataBaseName"].ToString() + @""") , ";
                    }
                    MySqlQuery = MySqlQuery.Substring(0, MySqlQuery.Length - 3);
                    mysqlDB.setQuery(MySqlQuery);
                    Db.setQuery(SqlQuery);
                    if (mysqlDB.Query_Execute() >= 0)
                    {
                        Db.Query_Execute();
                        SqlQuery = "";
                        MySqlQuery = "";
                    }
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception("2EventLogError" + ex.Message));
            }

        }
        public void UpdateAUTConsoleQuerySendStatus(ClassLibrary.JDataBase Db, ClassLibrary.JMySQLDataBase mysqlDB = null)
        {
            try
            {
                Db.setQuery(@"SELECT Code
                            FROM AUTConsoleQuerySendStatus
                            WHERE Status = 1 AND InsertDate > DATEADD(DAY, -7, GETDATE()) 
                            ORDER BY InsertDate");
                DataTable Dt = Db.Query_DataTable();
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    string Codes = "";
                    for (int i = 0; i < Dt.Rows.Count; i++)
                        Codes += Dt.Rows[i]["Code"] + " , ";
                    Codes = Codes.Substring(0, Codes.Length - 3);
                    mysqlDB.setQuery(@"SELECT `Code` FROM `GetQuery` WHERE `Code` IN (" + Codes + ") AND `State` = 1");
                    DataTable MySqlDt = mysqlDB.Query_DataTable();
                    if (MySqlDt != null && MySqlDt.Rows.Count > 0)
                    {
                        Codes = "";
                        for (int i = 0; i < MySqlDt.Rows.Count; i++)
                            Codes += MySqlDt.Rows[i]["Code"] + " , ";
                        Codes = Codes.Substring(0, Codes.Length - 3);
                        Db.setQuery(@"UPDATE AUTConsoleQuerySendStatus SET Status = 2
                            WHERE Code IN (" + Codes + ")");
                        Db.Query_Execute();
                    }
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception("3EventLogError" + ex.Message));
            }

        }
        public void SendMessage(ClassLibrary.JDataBase Db, ClassLibrary.JMySQLDataBase mysqlDB)
        {

            try
            {
                int MySqlMaxCodeInt = 0;
                DataTable MySqlMaxCode = null;
                DataTable LastInserts = new DataTable();
                do
                {
                    mysqlDB.setQuery(@"SELECT  IFNULL(max( `Code` ),0) AS max_value FROM `getsettings`");
                    MySqlMaxCode = mysqlDB.Query_DataTable();
                    System.Threading.Thread.Sleep(500);
                }
                while (MySqlMaxCode == null);
                MySqlMaxCodeInt = Convert.ToInt32(MySqlMaxCode.Rows[0]["max_value"].ToString());
                Db.setQuery(@"
                    IF OBJECT_ID('tempdb..#Messagetemp') IS NOT NULL DROP Table #Messagetemp
                    SELECT TOP 100 Code, BusNumber, MessageText INTO #Messagetemp 
                   FROM dbo.AutConsoleMessage WHERE Status = 0 and insertdate
                   between DATEADD(day,-1,getdate()) and dateadd(day,1,getdate()) ORDER BY InsertDate DESC
                    SELECT Code, BusNumber, MessageText FROM #Messagetemp"
                    );
                DataTable Dt = Db.Query_DataTable();
                string MySqlQuery = "";
                //ClassLibrary.JSystem.Except.AddException(new Exception("4EventLogErrorr" + Dt.Rows.Count));
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    MySqlQuery += @"INSERT INTO `getsettings`(`Code`, `busserial`, `Field`, `Value`, `State`, `StartDate`) VALUES ";
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        MySqlMaxCodeInt++;
                        MySqlQuery += @" (" + MySqlMaxCodeInt.ToString() + @", " + Dt.Rows[i]["BusNumber"].ToString() + @", 'users/serverMessage', '"
                            + Dt.Rows[i]["MessageText"].ToString().Replace("\"", "\"\"") + @"',0 ,'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "') , ";
                    }
                    MySqlQuery = MySqlQuery.Substring(0, MySqlQuery.Length - 3);
                    //ClassLibrary.JSystem.Except.AddException(new Exception("4EventLogErrort" + MySqlQuery));
                    mysqlDB.setQuery(MySqlQuery);
                    mysqlDB.Query_Execute();
                    {
                        Db.setQuery("UPDATE dbo.AutConsoleMessage SET Status = 1 WHERE Code IN (SELECT Code FROM #Messagetemp)");
                        Db.Query_Execute();
                    }
                }
                //ClassLibrary.JSystem.Except.AddException(new Exception("4EventLogError" + MySqlMaxCodeInt));
                //LastInserts = new DataTable();
                //mysqlDB.setQuery(@"SELECT  `busserial` FROM `getsettings` where `Field` = 'users/serverMessage' and `State` <> 1");
                //LastInserts = mysqlDB.Query_DataTable();
                //Db.setQuery(@"select 116 LineNumber, BUSNumber = 9999, 5 cnt");
                //DataTable Dt = Db.Query_DataTable();
                //string MySqlQuery = "";
                ////ClassLibrary.JSystem.Except.AddException(new Exception("4EventLogErrorr" + Dt.Rows.Count));
                //if (Dt != null && Dt.Rows.Count > 0)
                //{
                //    MySqlQuery += @"INSERT INTO `getsettings`(`Code`, `busserial`, `Field`, `Value`, `State`, `StartDate`) VALUES ";
                //    for (int i = 0; i < Dt.Rows.Count; i++)
                //    {
                //        string Message = "تعداد " + Dt.Rows[i]["cnt"].ToString() + " اتوبوس در مسیر " + Dt.Rows[i]["LineNumber"].ToString();
                //        MySqlMaxCodeInt++;
                //        MySqlQuery += @" (" + MySqlMaxCodeInt.ToString() + @", " + Dt.Rows[i]["BUSNumber"].ToString() + @", 'users/serverMessage', """
                //            + Message.Replace("\"", "\"\"") + @""",0 ,'" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/"
                //            + DateTime.Now.Day + @" " + DateTime.Now.Hour + @":" + DateTime.Now.Minute + @":" + DateTime.Now.Second + "') , ";
                //    }
                //    MySqlQuery = MySqlQuery.Substring(0, MySqlQuery.Length - 3);
                //    //ClassLibrary.JSystem.Except.AddException(new Exception("4EventLogErrort" + MySqlQuery));
                //    mysqlDB.setQuery(MySqlQuery);
                //    mysqlDB.Query_Execute();
                //}
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception("4EventLogErroru" + ex.Message));
            }


        }
    }
}
