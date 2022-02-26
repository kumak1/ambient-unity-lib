using System;
using System.Collections.Generic;

namespace AmbientClient
{
    public class AmbientSendParameter
    {
        public string D1 = "";
        public string D2 = "";
        public string D3 = "";
        public string D4 = "";
        public string D5 = "";
        public string D6 = "";
        public string D7 = "";
        public string D8 = "";
        public string Comment = "";

        public float? Lat = null;
        public float? Lng = null;

        public DateTime? Created = null;

        public AmbientSendParameter()
        {
        }

        public Dictionary<string, string> ToDictionary(int index = 0)
        {
            var content = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(D1))
                content.Add($"data[{index}][{nameof(D1).ToLower()}]", D1);

            if (!string.IsNullOrEmpty(D2))
                content.Add($"data[{index}][{nameof(D2).ToLower()}]", D2);

            if (!string.IsNullOrEmpty(D3))
                content.Add($"data[{index}][{nameof(D3).ToLower()}]", D3);
            
            if (!string.IsNullOrEmpty(D4))
                content.Add($"data[{index}][{nameof(D4).ToLower()}]", D4);

            if (!string.IsNullOrEmpty(D5))
                content.Add($"data[{index}][{nameof(D5).ToLower()}]", D5);

            if (!string.IsNullOrEmpty(D6))
                content.Add($"data[{index}][{nameof(D6).ToLower()}]", D6);

            if (!string.IsNullOrEmpty(D7))
                content.Add($"data[{index}][{nameof(D7).ToLower()}]", D7);

            if (!string.IsNullOrEmpty(D8))
                content.Add($"data[{index}][{nameof(D8).ToLower()}]", D8);

            if (!string.IsNullOrEmpty(Comment))
                content.Add($"data[{index}][cmnt]", Comment);

            if (Lat != null && Lng != null)
            {
                content.Add($"data[{index}][lat]", Lat.ToString());
                content.Add($"data[{index}][lng]", Lng.ToString());
            }

            if (Created != null)
                content.Add($"data[{index}][created]", Created.ToString());

            return content;
        }

        public Dictionary<string, string> ToDictionaryWithKey(string writeKey, int index = 0)
        {
            var param = ToDictionary(index);
            param.Add("writeKey", writeKey);
            return param;
        }
    }
}