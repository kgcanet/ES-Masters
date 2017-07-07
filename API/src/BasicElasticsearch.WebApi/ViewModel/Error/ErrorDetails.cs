using Newtonsoft.Json;
using System.IO;

namespace BasicElasticsearch.WebApi.ViewModel
{
    public class ErrorDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorDetails"/> class.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="Status">The status.</param>
        /// <param name="Code">The code.</param>
        /// <param name="Title">The title.</param>
        /// <param name="Detail">The detail.</param>
        /// <exception cref="InvalidDataException">Id is a required property for ErrorDetails and cannot be null</exception>
        public ErrorDetails(string Id = null, int? Status = null, string Code = null, string Title = null, string Detail = null)
        {
            if (Id == null)
            {
                throw new InvalidDataException("Id is a required property for ErrorDetails and cannot be null");
            }
            else
            {
                this.Id = Id;
            }
            this.Status = Status;
            this.Code = Code;
            this.Title = Title;
            this.Detail = Detail;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Detail
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
