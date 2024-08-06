using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BSLHRAPI.Models
{
    public class Generic
    {

        private const string SecurityKey = "ComplexKeyHere_12121";
        public static string EncryptText(string PlainText)
        {            
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);

            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            objTripleDESCryptoService.Key = securityKeyArray;
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string DecryptText(string CipherText)
        {
            byte[] toEncryptArray = Convert.FromBase64String(CipherText);
            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            objTripleDESCryptoService.Key = securityKeyArray;
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            objTripleDESCryptoService.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }


    }
    public static class Logger
    {
        public static void WriteLog(string FunctionName, string message, StackTrace stStrack)
        {
            string LogPath = ConfigurationManager.AppSettings["logPath"] + System.DateTime.Today.ToString("dd-MM-yyyy") + "." + "txt";
            FileInfo LogFileInfo = new FileInfo(LogPath);
            DirectoryInfo LogDirInfo = new DirectoryInfo(LogFileInfo.DirectoryName);
            if (!LogDirInfo.Exists) LogDirInfo.Create();
            using (FileStream fileStream = new FileStream(LogPath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(fileStream))
                {
                    //var st = new StackTrace(true);
                    StackFrame frame = null;
                    int LineNumber = 0;
                    for (int i = 0; i < stStrack.FrameCount; i++)
                    {
                        frame = stStrack.GetFrame(i);
                        if (frame.GetFileLineNumber() > 0)
                        {
                            LineNumber = frame.GetFileLineNumber();
                            break;
                        }
                    }
                    log.WriteLine($"{DateTime.Now} : {FunctionName} {LineNumber} {message}");
                }
            }
        }
    }


}