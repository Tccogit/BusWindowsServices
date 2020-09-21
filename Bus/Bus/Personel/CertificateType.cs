using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Personel
{
    public class JCertificateType: ClassLibrary.JSubBaseDefine
    {
        public JCertificateType()
            : base(ClassLibrary.JBaseDefine.CertificateType)
        {
        }
    }

    public class JCertificateTypes : ClassLibrary.JSubBaseDefines
    {
        public JCertificateTypes()
            : base(ClassLibrary.JBaseDefine.CertificateType)
        {
        }
    }
}
