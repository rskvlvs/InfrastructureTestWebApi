using Microsoft.Extensions.Options;
using StatisticsLogic.Repositories.Interfaces;
using StatisticsStorage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsLogic.Repositories
{
    /// <summary>
    /// Repository for work with errors.
    /// </summary>
    public class ErrorRepository : IErrorRepository
    {
        #region Fields: Public
        private readonly FilePathsOptions _filePathOptions;
        #endregion
        public ErrorRepository(IOptions<FilePathsOptions> options)
        {
            _filePathOptions = options.Value;
        }

        /// <summary>
        /// Generates errors and save them to file.
        /// </summary>
        public async Task GenerateErrorsAsync()
        {
            if (!File.Exists(_filePathOptions.GeneratedErrors))
            {
                throw new FileNotFoundException($"Файл не найден!");
            }

            var random = new Random();
            var errorsCount = random.Next(10_000, 50_000);
            var header = "Timestamp;Severity;Product;Version;ErrorCode";

            using (var streamWriter = new StreamWriter(_filePathOptions.GeneratedErrors))
            {
                await streamWriter.WriteLineAsync(header);
                for (var i = 0; i < errorsCount; i++)
                {
                    var error = Error.GenerateError(random);
                    await streamWriter.WriteLineAsync(error.ToString());
                }
            }
        }

        public async Task AnalyzeErrorsAsync()
        {
            var errors = await GetErrorsFromFileAsync();

        }



        public async Task<List<Error>> GetErrorsFromFileAsync()
        {
            if (!File.Exists(_filePathOptions.GeneratedErrors))
            {
                throw new FileNotFoundException($"Файл не найден!");
            }

            var emptyFileException = "Ошибки не сгенерированы!";
            var errors = new List<Error>();
            using (var streamReader = new StreamReader(_filePathOptions.GeneratedErrors))
            {
                var header = await streamReader.ReadLineAsync();
                if (string.IsNullOrEmpty(header))
                {
                    throw new ArgumentNullException(emptyFileException);
                }

                while (!streamReader.EndOfStream)
                {
                    var dataLine = streamReader.ReadLine();

                    if (string.IsNullOrEmpty(dataLine))
                    {
                        continue;
                    }

                    var parts = dataLine.Split(';');

                    if (parts.Length != 5)
                    {
                        continue;
                    }

                    var error = new Error()
                    {
                        Timestamp = DateTime.Parse(parts[0]),
                        Severity = parts[1],
                        Product = parts[2],
                        Version = int.Parse(parts[3]),
                        ErrorCode = int.Parse(parts[4])
                    };
                    errors.Add(error);
                }
                return errors;
            }
        }
    }
}
