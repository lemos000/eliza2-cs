using eliza2_api.Model.DTO;
using eliza2_api.Model.Entity;

namespace eliza2_api.Services
{
    public class GeminiService
    {
        private const string ApiKey = "AIzaSyDDdpR2E4yAEQ1_pziXGF8iSF6R9NROrkI";
        private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key=";


        public async Task<MensagemRespDto> EnviarMensagem(MensagemRequestDTO req)
        {

            using var client = new HttpClient();

            var requestBody = new
            {
                contents = new[]
                {
                new
                    {
                    parts = new[]
                        {
                        new { text = req.Texto }
                        }
                    }
                }   
            };
            var response = await client.PostAsJsonAsync($"{BaseUrl}{ApiKey}", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadFromJsonAsync<GeminiDesDTO.RespostaGemini>();

                Console.WriteLine("Response from API:");
                if (resultado?.Candidates != null && resultado.Candidates.Count > 0)
                {
                    MensagemRespDto resp = new MensagemRespDto();
                    resp.RespostaBot = resultado.Candidates[0].Content.Parts[0].Text;
                    return (resp);
                }
                else {
                    throw new Exception("Houve um mal funcionamento na resposta da api");
                }
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception("Não foi possível enviar a mensagem: " + errorResponse);
            }
        }
    }
}
