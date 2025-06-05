namespace eliza2_api.Model.DTO
{
    public class GeminiDesDTO
    {
        public class RespostaGemini
        {
            public List<Candidate> Candidates { get; set; }
        }

        public class Candidate
        {
            public Content Content { get; set; }
        }

        public class Content
        {
            public List<Part> Parts { get; set; }
        }

        public class Part
        {
            public string Text { get; set; }
        }
    }
}
