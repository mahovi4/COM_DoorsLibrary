using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM_DoorsLibrary
{
    public delegate void KVDFileMapperStepHandler(KVDFileMapper sender, bool complete);

    public class KVDFileMapper
    {
        public event KVDFileMapperStepHandler StepComplete;

        public List<string> Errors { get; } 
            = new List<string>();

        public string KVDNum { get; }

        private readonly KVD product;
        private readonly string basePath;
        private readonly string targetPath;
        private readonly string year;

        public KVDFileMapper(KVD kvd, string basePath, string targetPath)
        {
            product = kvd;
            KVDNum = kvd.Data.Num;
            this.basePath = basePath;
            this.targetPath = targetPath;
            var date = DateTime.Now;
            year = date.Year.ToString();
            year = year.Substring(year.Length - 2, 2);
        }

        public void Run()
        {
            if (!Directory.Exists(targetPath))
                throw new ArgumentException($"Папка назначения {targetPath} не существует!");

            var dir = new DirectoryInfo($@"{targetPath}\{year}.{product.Data.ER}\{product.Data.Num}");

            if (!dir.Exists) dir.Create();

            foreach (var path in product.Pathes)
            {
                var p = basePath + path.Value;
                if (!File.Exists(p))
                {
                    Errors.Add($"Файл {p} не найден в базе!");
                    OnStepComplete(false);
                    continue;
                }

                var ok = false;
                try
                {
                    File.Copy(p, $@"{dir.FullName}\{path.Key}");
                    ok = true;
                }
                catch (Exception ex)
                {
                    Errors.Add(ex.Message);
                }
                finally
                {
                    OnStepComplete(ok);
                }
            }
        }

        private void OnStepComplete(bool complete)
        {
            StepComplete?.Invoke(this, complete);
        }
    }
}
