using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Net.Http.Headers;

namespace Stocks.Domain.Formats                                                 
{
    public static class CsvFormatterExtension
    {

        public static IMvcCoreBuilder AddCsvSerializerFormatters(this IMvcCoreBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return AddCsvSerializerFormatters(builder, csvFormatterOptions: null);
        }

        public static IMvcCoreBuilder AddCsvSerializerFormatters(this IMvcCoreBuilder builder, CsvFormatterOptions csvFormatterOptions)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddFormatterMappings(m => m.SetMediaTypeMappingForFormat("csv", new MediaTypeHeaderValue("text/csv")));

            if (csvFormatterOptions == null)
            {
                csvFormatterOptions = new CsvFormatterOptions();
            }

            if (string.IsNullOrWhiteSpace(csvFormatterOptions.CsvDelimiter))
            {
                throw new ArgumentException("CsvDelimiter cannot be empty");
            }

            builder.AddMvcOptions(options => options.InputFormatters.Add(new CsvInputFormatter(csvFormatterOptions)));
            builder.AddMvcOptions(options => options.OutputFormatters.Add(new CsvOutputFormatter(csvFormatterOptions)));

            return builder;
        }
    }
}
