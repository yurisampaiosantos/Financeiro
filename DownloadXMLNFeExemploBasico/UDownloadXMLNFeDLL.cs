using System;
using System.Runtime.InteropServices;

//***********************ATENÇÃO*************************************
//É necessário alterar a opção "Target CPU" para "x86"
//***********************ATENÇÃO*************************************

public class UDownloadXMLNFeDLL
    {
        [ DllImport("BaixarXMLNFe.dll")]
        public static extern bool Proxy(string Host, int Port, string User, string Pass);

        [ DllImport("BaixarXMLNFe.dll")]
        public static extern bool Captcha(string SalvarEm);

        [ DllImport("BaixarXMLNFe.dll")]
        public static extern void Https(int Sim);

        [DllImport("BaixarXMLNFe.dll", EntryPoint = "GetCertificadoDigital")]
        private static extern IntPtr FGetCertificadoDigital();
        public static string GetCertificadoDigital()
        {
            return Marshal.PtrToStringAnsi(FGetCertificadoDigital());
        }
		
		[DllImport("BaixarXMLNFe.dll", EntryPoint = "GetCertificadoDigitalLocal")]
        private static extern IntPtr FGetCertificadoDigitalLocal();
        public static string GetCertificadoDigitalLocal()
        {
            return Marshal.PtrToStringAnsi(FGetCertificadoDigitalLocal());
        }
		
        [DllImport("BaixarXMLNFe.dll", EntryPoint = "Msg")]
        private static extern IntPtr FMsg();  
        public static string Msg()
        {
            return Marshal.PtrToStringAnsi(FMsg());
        }
        [ DllImport("BaixarXMLNFe.dll")]
        public static extern void SetCertificadoDigital(string CertSerialNumber);
		
		[ DllImport("BaixarXMLNFe.dll")]
        public static extern void SetCertificadoDigitalLocal(string CertSerialNumber);

        [ DllImport("BaixarXMLNFe.dll")]
        public static extern bool BaixarXMLNFeSemCert(string Chave, string Captcha, string SalvarEm);

        [ DllImport("BaixarXMLNFe.dll")]
        public static extern bool BaixarXMLNFeComCert(string Chave, string Captcha, string SalvarEm);

        [DllImport("BaixarXMLNFe.dll")]
        public static extern bool BaixarXMLNFeComCertAuto(string Chave, string SalvarEm, string ChaveLeitorCaptcha, int Tentativas, int MostrarProgresso);
    
        [DllImport("BaixarXMLNFe.dll")]
        public static extern bool BaixarXMLNFeSemCertAuto(string Chave, string SalvarEm, string ChaveLeitorCaptcha, int Tentativas, int MostrarProgresso);

        [ DllImport("BaixarXMLNFe.dll")]
        public static extern void DLLLicenca(string Chave);

        [ DllImport("BaixarXMLNFe.dll")]
        public static extern bool CaptchaLer(string ChaveCaptcha, string ArquivoImagem);

        [ DllImport("BaixarXMLNFe.dll")]
        public static extern string CaptchaLerTexto();

        [ DllImport("BaixarXMLNFe.dll")]
        public static extern bool Imprimir(string ArquivoXML, string LogoMarca);

        [ DllImport("BaixarXMLNFe.dll")]
        public static extern bool ExportarPDF(string ArquivoXML, string LogoMarca, string PDF);

        [DllImport("BaixarXMLNFe.dll")]
        public static extern void DLLRegistra(string PastaDestino);

        [DllImport("BaixarXMLNFe.dll")]
        public static extern void CaptchaBossURL(string URL);

    } // end UDownloadXMLNFeDLL


