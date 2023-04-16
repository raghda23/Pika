using System.Collections;
using System.Collections.Generic;

namespace Pikia.APIs.Errors
{
    public class ApiValidationResponse : APIsResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationResponse() : base(400)
        {

        }
    }
}
