namespace KeyGenerator
{
    public class RegText
    {
        public RegText(string regName)
        {
            RegName = regName;
        }
        public string RegName { get; set; }

        public string Email { get; set; }

        public string MachineCode { get; set; }

        public string RegCode { get; set; }
    }
}
