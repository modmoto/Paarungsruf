namespace Paarungsruf.Server.NewRecruit;

public class TournamentRepository
{
    private readonly HttpClient _httpClient;

    public TournamentRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<NewRecruitTournamentDto>> Load(DateTimeOffset startTime, DateTimeOffset endTime)
    {
        var result = await _httpClient.PostAsJsonAsync("api/tournaments", new { start = startTime.ToString("yyyy-MM-dd"), end = endTime.ToString("yyyy-MM-dd") });
        return await result.Content.ReadFromJsonAsync<List<NewRecruitTournamentDto>>();
    }
    
    public class Country
    {
        public string _id { get; set; }
        public string flag { get; set; }
        public string name { get; set; }
    }
    public class NewRecruitTournamentDto
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string @short { get; set; }
        public long participants { get; set; }
        public long participants_per_team { get; set; }
        public long team_proposals { get; set; }
        public long team_polong_cap { get; set; }
        public long team_polong_min { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public long status { get; set; }
        public bool showlists { get; set; }
        public bool discord_notify_reports { get; set; }
        public string address { get; set; }
        public long price { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string rules { get; set; }
        public long tables { get; set; }
        public long group_size { get; set; }
        public long group_winners { get; set; }
        public long group_win_condition { get; set; }
        public bool group_letters { get; set; }
        public long roundNumber { get; set; }
        public long confirmed_participants { get; set; }
        public long type { get; set; }
        public long currentRound { get; set; }
        public long visibility { get; set; }
        public long stageReload { get; set; }
        public Country country { get; set; }
        public long id_game_system { get; set; }
        public List<string> id_owner { get; set; }
        public long version { get; set; }
        public List<Team> teams { get; set; }
        public DateTime mod_date { get; set; }
        public long lists_per_participant { get; set; }
        public bool enforce_online_payment { get; set; }
        public List<string> id_notification_subscribers { get; set; }
        public bool full { get; set; }
        public bool allow_participant_report_delete { get; set; }
        public bool enforce_discord { get; set; }
        public bool enforce_real_name { get; set; }
        public bool has_round_data { get; set; }
        public bool hide_list_from_admins { get; set; }
        public string last_message_id { get; set; }
        public bool use_default_scoring { get; set; }
        public bool hide_incomplete_round_results { get; set; }
        public List<Round> rounds { get; set; }
        public long avoidSameMatchup { get; set; }
        public long pairings_type { get; set; }
        public bool tableMatch { get; set; }
    }

    public class Round
    {
        public string _id { get; set; }
        public long type { get; set; }
        public List<object> dropouts { get; set; }
        public bool lock_reports { get; set; }
    }

    public class Team
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public long status { get; set; }
        public List<string> participants { get; set; }
        public string id_captain { get; set; }
        public long paid { get; set; }
        public string id_sales { get; set; }
        public List<object> extra_polongs { get; set; }
    }
}