using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BasicElasticsearch.WebApi.ViewModel
{
    /// <summary>
    /// Error model
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="Errors">The errors.</param>
        /// <exception cref="InvalidDataException">Errors is a required property for Error and cannot be null</exception>
        public Error(List<ErrorDetails> Errors = null)
        {
            if (Errors == null)
            {
                throw new InvalidDataException("Errors is a required property for Error and cannot be null");
            }
            else
            {
                this.Errors = Errors;
            }
        }

        public List<ErrorDetails> Errors { get; set; }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
