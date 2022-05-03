namespace AcademyF.Week2.EsercitazioneDesignPattern.Entities
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }
        public int ProductivityRate { get; set; }
        public int AbsenceRate { get; set; }

        public virtual string ViewBenefit()
        {
            return "";
        }
    }
}