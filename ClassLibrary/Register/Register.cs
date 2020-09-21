using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace ClassLibrary
{
    public class JRegister: JSystem
    {
        private const string RootName = "ERP_7_2011";
        private RegistryKey _Register;
        public JRegister()
        {
            _Register = Registry.CurrentUser.OpenSubKey(RootName);
            if (_Register == null)
            {
                _Register = Registry.CurrentUser.CreateSubKey(RootName);
                
            }
        }

        public RegistryKey CreateSubKey(string pName)
        {
            return _Register.CreateSubKey(pName);
        }

        public void SetValue(string pName, object Value)
        {
            _Register.SetValue(pName, Value);
        }

        public void Close()
        {
            _Register.Close();
        }

        public override void Dispose()
        {
            Close();
            base.Dispose();
        }
    }
}
