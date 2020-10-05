namespace SirilCmd
{
    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.Security.Principal;

    class Program
    {
        static void Main()
        {
            var stream = new NamedPipeClientStream(
                ".",
                "siril_command.out",
                PipeDirection.In,
                PipeOptions.None,
                TokenImpersonationLevel.Impersonation);
            stream.Connect();
            using (var streamReader = new StreamReader(stream))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }
    }
}
