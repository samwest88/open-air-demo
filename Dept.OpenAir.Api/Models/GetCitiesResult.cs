namespace Dept.OpenAir.Api.Models
{
    public class GetCitiesResult
    {
        public Meta? Meta { get; set; }
        public Result[] Results { get; set; } = new Result[0];
    }

}
