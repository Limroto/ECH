namespace ECH.Infrastructure.Implementation
{
    public class StkBoard
    {
        public StkBoard(string name, int port, StkStateChange state)
        {
            Name = name;
            ComPort = port;
            State = state;
        }

        public StkStateChange State { get; set; }
        public string Name { get; private set; }
        public int ComPort { get; private set; }
    }
}