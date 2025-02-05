using Framework.Common.Utils;
using System;
using System.IO;

namespace Fly.WinForms.Core.config
{
    /// <summary>
    /// 数据库连接配置文件
    /// </summary>
    public class ConnectConfig
    {
        private readonly string _filePath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.SetupInformation.ApplicationBase).Parent.FullName, "Config\\connectSetting.ini");
        private readonly IniFile _iniFile;
        public ConnectConfig()
        {
            _iniFile = new IniFile(_filePath);
        }
        public ConnectConfig(string path)
        {
            if (!string.IsNullOrEmpty(path))
                _filePath = path;
            _iniFile = new IniFile(_filePath);
        }

        public string DatabaseType
        {
            get
            {
                return _iniFile.Read("Database", "DatabaseType");
            }
        }
        public string ConnectionString
        {
            get
            {
                return _iniFile.Read("Database", "ConnectionString");
            }
        }
        public int UpperPoolSize
        {
            get
            {
                return Convert.ToInt32(_iniFile.Read("Database", "UpperPoolSize", "200"));
            }
        }
        public int MaxPoolSize
        {
            get
            {
                return Convert.ToInt32(_iniFile.Read("Database", "MaxPoolSize", "100"));
            }
        }
        public int MinPoolSize
        {
            get
            {
                return Convert.ToInt32(_iniFile.Read("Database", "MinPoolSize", "10"));
            }
        }
        public bool EnableSqlLogging
        {
            get
            {
                return Convert.ToBoolean(_iniFile.Read("Database", "EnableSqlLogging", "false"));
            }
        }
        public int SlowSqlTreshold
        {
            get
            {
                return Convert.ToInt32(_iniFile.Read("Database", "SlowSqlTreshold", "200"));
            }
        }
    }
}
