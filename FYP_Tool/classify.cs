using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;  // Make sure you add a reference to Newtonsoft.Json to parse JSON

namespace FYP_Tool
{
    public class Classifier
    {
        private readonly string _apiUrl = "http://127.0.0.1:5000/classify";  // Flask API endpoint

        // This method sends the image metrics to the Flask API and retrieves the classification
        public async Task<string> GetPredictionAsync(double textSizeBits, double imageCapacityKb, double psnr, double mse, double ssim)
        {
            using (var client = new HttpClient())
            {
                // Set up the base address and headers for the request
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Prepare the JSON payload to send to the API
                var json = $"{{\"text_size_bits\": {textSizeBits}, \"image_capacity_kb\": {imageCapacityKb}, \"psnr\": {psnr}, \"mse\": {mse}, \"ssim\": {ssim}}}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send POST request to the Flask API
                HttpResponseMessage response = await client.PostAsync("", content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the API response
                    string result = await response.Content.ReadAsStringAsync();

                    // Parse the JSON response to extract the classification
                    var jsonResult = JObject.Parse(result);
                    string classification = jsonResult["classification"].ToString();  // Get the classification value

                    // Return the classification result
                    return classification;
                }
                else
                {
                    throw new Exception("API request failed with status code: " + response.StatusCode);
                }
            }
        }
    }
}
