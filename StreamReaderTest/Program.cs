namespace StreamReaderTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var writer = new StreamWriter("writer.txt");

            for (int i = 1; i <= 10; i++)
                writer.WriteLine("To jest linia nr {0} tekstu", i);

            writer.Close();
            writer = new StreamWriter("reader.txt");
            var reader = new StreamReader("writer.txt");

            var counter = 0;

            while(!reader.EndOfStream)
            {
                var lineFromReader = reader.ReadLine();
                writer.WriteLine($"Skopiowany tekst -> {lineFromReader}");
                counter++;
            }

            /* jest to drugi sposób na zrobienie powyższej pętli while
            var lineFromReader = reader.ReadLine();
            while(lineFromReader != null)
            {
                writer.WriteLine($"Skopiowany tekst -> {lineFromReader}");
                counter++;
                lineFromReader = reader.ReadLine();
            }
            działa dokładnie tak samo */


            Console.WriteLine(counter.ToString());

            writer.Close();
            reader.Close();

            Console.WriteLine();

            Console.WriteLine($"Czy plik reader istnieje? {File.Exists("reader.txt")}");
            FileInfo fileInfo = new FileInfo("reader.txt");
            Console.WriteLine($"Czy plik reader istnieje? Obiekt file info: {fileInfo.Exists}");
        }
    }
}
