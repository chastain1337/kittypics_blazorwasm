namespace KittyPics.Shared;

public class Pic
{
    public int PicID { get; set; }
    public string Url { get; set; }
    public int Votes { get; set; }
    public DateTime? LastVote { get; set; }
}