using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace HelloMD.Dtos
{
    public class ResponseDto
    {
        public Boolean success;
        public String message;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? status_code;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? error_code;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string,object>? data;

        public ResponseDto() { }
        public ResponseDto(Boolean success, string message) {
            this.success = success;
            this.message = message;
        }
        public ResponseDto(Boolean success, string message, string key, object? data)
        {
            Builder(success, message, key, data);
        }
        public ResponseDto(Boolean success, string message, string key, object? data, int statcode, int errorcode)
        {
            Builder(success, message, key, data, statcode, errorcode);
        }

        public ResponseDto Builder(Boolean success, string message,string key, object? data)
        {
            this.success = success;
            this.message = message;
            AddData(key,data);
            return this;
        }
        public ResponseDto Builder(Boolean success, string message,string key, object? data, int statcode, int errorcode)
        {
            this.success = success;
            this.message = message;
            status_code = statcode;
            error_code = errorcode;
            AddData(key,data);
            return this;
        }
       
        public ResponseDto AddData(string key,object? data)
        {
            if (data != null)
            {
                if (this.data == null)
                    this.data = new Dictionary<string, object>();
                this.data.Add(key, data);
            }
                return this;
        }
    }
}
