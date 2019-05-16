using System;
using System.Runtime.InteropServices;

//***********************ATENÇÃO*************************************
//É necessário alterar a opção "Target CPU" para "x86"
//***********************ATENÇÃO*************************************

public class UDownloadXMLCTeDLL
    {
        [ DllImport("BaixarXMLCTe.dll")]
        public static extern bool Proxy(string Host, int Port, string User, string Pass);

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern bool Captcha(string SalvarEm);

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern void Https(int Sim);

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern string GetCertificadoDigital();
		
		[ DllImport("BaixarXMLCTe.dll")]
        public static extern string GetCertificadoDigitalLocal();

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern string Msg();

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern void SetCertificadoDigital(string CertSerialNumber);
		
		[ DllImport("BaixarXMLCTe.dll")]
        public static extern void SetCertificadoDigitalLocal(string CertSerialNumber);

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern bool BaixarXMLCTeSemCert(string Chave, string Captcha, string SalvarEm);

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern bool BaixarXMLCTeComCert(string Chave, string Captcha, string SalvarEm);

        [DllImport("BaixarXMLCTe.dll")]
        public static extern bool BaixarXMLCTeComCertAuto(string Chave, string SalvarEm, string ChaveLeitorCaptcha, int Tentativas, int MostrarProgresso);
    
        [DllImport("BaixarXMLCTe.dll")]
        public static extern bool BaixarXMLCTeSemCertAuto(string Chave, string SalvarEm, string ChaveLeitorCaptcha, int Tentativas, int MostrarProgresso);

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern void DLLLicenca(string Chave);

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern bool CaptchaLer(string ChaveCaptcha, string ArquivoImagem);

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern string CaptchaLerTexto();

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern bool Imprimir(string ArquivoXML, string LogoMarca);

        [ DllImport("BaixarXMLCTe.dll")]
        public static extern bool ExportarPDF(string ArquivoXML, string LogoMarca, string PDF);

        [DllImport("BaixarXMLCTe.dll")]
        public static extern void DLLRegistra(string PastaDestino);

    } // end UDownloadXMLCTeDLL


