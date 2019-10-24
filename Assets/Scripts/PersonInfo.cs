[System.Serializable]
public class Score
{
    public int totalScore;
    public int stageScore;
    public int maxScore;
}

public class PersonInfo
{
    public string Name;
    public int Age;
    public string PhonNumber;
    public string Email;
    public Score Score;

    public PersonInfo(string name, int age , string phoneNumber, string email, Score score)
    {
        this.Name = name;
        this.Age = age;
        this.PhonNumber = phoneNumber;
        this.Email = email;
        this.Score = score;
    }
}