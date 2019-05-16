using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOD
{
    public class LayoutSAP
    {
        private string _dataDocumento;

        public string DataDocumento
        {
            get { return _dataDocumento; }
            set { _dataDocumento = value; }
        }
        private string _empresa;

        public string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }
        private string _dataLancamento;

        public string DataLancamento
        {
            get { return _dataLancamento; }
            set { _dataLancamento = value; }
        }
        private string _mes;

        public string Mes
        {
            get { return _mes; }
            set { _mes = value; }
        }
        private string _moeda;

        public string Moeda
        {
            get { return _moeda; }
            set { _moeda = value; }
        }
        private string _notaFiscal;

        public string NotaFiscal
        {
            get { return _notaFiscal; }
            set { _notaFiscal = value; }
        }
        private string _textoCabecalho;

        public string TextoCabecalho
        {
            get { return _textoCabecalho; }
            set { _textoCabecalho = value; }
        }
        private string _fornecedor;

        public string Fornecedor
        {
            get { return _fornecedor; }
            set { _fornecedor = value; }
        }
        private string _valorTotal;

        public string ValorTotal
        {
            get { return _valorTotal; }
            set { _valorTotal = value; }
        }
        private string _vencimento;

        public string Vencimento
        {
            get { return _vencimento; }
            set { _vencimento = value; }
        }
        private string _contaDespesa;

        public string ContaDespesa
        {
            get { return _contaDespesa; }
            set { _contaDespesa = value; }
        }
        private string _valorItem;

        public string ValorItem
        {
            get { return _valorItem; }
            set { _valorItem = value; }
        }
        private string _centroCusto;

        public string CentroCusto
        {
            get { return _centroCusto; }
            set { _centroCusto = value; }
        }
        private string _ordemInterna;

        public string OrdemInterna
        {
            get { return _ordemInterna; }
            set { _ordemInterna = value; }
        }
        private string _elementoPep;

        public string ElementoPep
        {
            get { return _elementoPep; }
            set { _elementoPep = value; }
        }
        private string _tipo;

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        private string _passageiro;

        public string Passageiro
        {
            get { return _passageiro; }
            set { _passageiro = value; }
        }
        private string _naoEncontrado;

        public string NaoEncontrado
        {
            get { return _naoEncontrado; }
            set { _naoEncontrado = value; }
        }

        private bool _alterar;

        public bool Alterar
        {
            get { return _alterar; }
            set { _alterar = value; }
        }
    }
}
