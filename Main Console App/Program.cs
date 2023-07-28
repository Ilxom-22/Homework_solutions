namespace MainProgram;

class Program
{
    static void Main(string[] args)
    {
        var st = new UltimateClassroomAttendance();

        st.Mark("John Doe", true);
        st.Mark("Lily James", true);
        st.Mark("James Carter", false, "Family emergency");
        st.Mark("Emily Johnson", false, "Caught a severe flu");
        st.Mark("Olivia Smith", true);

        st.Display();
    }
}