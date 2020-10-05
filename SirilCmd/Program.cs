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
            var inputStream = new NamedPipeClientStream(
                ".",
                "siril_command.in",
                PipeDirection.Out,
                PipeOptions.None,
                TokenImpersonationLevel.Impersonation);
            inputStream.Connect();

            var outputStream = new NamedPipeClientStream(
                ".",
                "siril_command.out",
                PipeDirection.In,
                PipeOptions.None,
                TokenImpersonationLevel.Impersonation);
            outputStream.Connect();

            using (var streamWriter = new StreamWriter(inputStream))
            {
                streamWriter.WriteLine("help");
            }

            using (var streamReader = new StreamReader(outputStream))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }
    }
}
