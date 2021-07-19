using eAgenda.Controladores.CompromissoModule;
using eAgenda.Controladores.ContatoModule;
using eAgenda.Controladores.Shared;
using eAgenda.Dominio.CompromissoModule;
using eAgenda.Dominio.ContatoModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace eAgenda.Tests.CompromissoModule
{
    [TestClass]
    public class ControladorCompromissoTest
    {
        ControladorContato controladorContato = null;
        ControladorCompromisso controladorCompromisso = null;

        public ControladorCompromissoTest()
        {
            controladorContato = new ControladorContato();
            controladorCompromisso = new ControladorCompromisso();
            Db.Update("DELETE FROM [TBCOMPROMISSO]");
            Db.Update("DELETE FROM [TBCONTATO]");
        }

        //Inserir
        [TestMethod]
        public void DeveInserir_Compromisso_ComContato()
        {
            //arrange
            var novoContato = new Contato("José Pedro", "jose.pedro@gmail.com", "321654987", "JP Ltda", "Dev");
            var novoCompromisso = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), novoContato);

            //action
            controladorContato.InserirNovo(novoContato);
            controladorCompromisso.InserirNovo(novoCompromisso);

            //assert
            var compromissoEncontrado = controladorCompromisso.SelecionarPorId(novoCompromisso.Id);
            compromissoEncontrado.Should().Be(novoCompromisso);
        }

        [TestMethod]
        public void DeveInserir_Compromisso_SemContato()
        {
            //arrange
            var novoCompromisso = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);

            //action
            controladorCompromisso.InserirNovo(novoCompromisso);

            //assert
            var compromissoEncontrado = controladorCompromisso.SelecionarPorId(novoCompromisso.Id);
            compromissoEncontrado.Should().Be(novoCompromisso);
        }

        [TestMethod]
        public void DeveNaoInserir_Compromisso_ParaHorarioOcupado()
        {
            //arrange
            var compromisso = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);
            controladorCompromisso.InserirNovo(compromisso);
            var novoCompromisso = new Compromisso("aumento de salarios", "restaurante", "Meet.com", new DateTime(2021, 09, 11), new TimeSpan(14, 30, 00), new TimeSpan(17, 30, 00), null);

            //action
            string resultado = controladorCompromisso.InserirNovo(novoCompromisso);

            //assert
            resultado.Should().Be("Nesta data e horário já existe um compromisso");
            List<Compromisso> compromissos = controladorCompromisso.SelecionarTodos();

            compromissos.Should().HaveCount(1);
        }

        //Editar
        [TestMethod]
        public void DeveEditar_Compromisso_MudandoContato()
        {
            //arrange
            var contato = new Contato("José Pedro", "jose.pedro@gmail.com", "321654987", "JP Ltda", "Dev");
            controladorContato.InserirNovo(contato);
            var novoContato = new Contato("Pedro", "pedro@gmail.com", "321654987", "P Ltda", "Dev");
            controladorContato.InserirNovo(novoContato);
            var compromisso = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 14), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), contato);
            controladorCompromisso.InserirNovo(compromisso);
            var novoCompromisso = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), novoContato);

            //action
            controladorCompromisso.Editar(compromisso.Id, novoCompromisso);

            //assert
            var compromissoAtualizado = controladorCompromisso.SelecionarPorId(compromisso.Id);
            compromissoAtualizado.Should().Be(novoCompromisso);
        }

        [TestMethod]
        public void DeveEditar_Compromisso_ExcluindoContato()
        {
            //arrange
            var contato = new Contato("José Pedro", "jose.pedro@gmail.com", "321654987", "JP Ltda", "Dev");
            controladorContato.InserirNovo(contato);
            var compromisso = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 14), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), contato);
            controladorCompromisso.InserirNovo(compromisso);
            var novoCompromisso = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);

            //action
            controladorCompromisso.Editar(compromisso.Id, novoCompromisso);

            //assert
            var compromissoAtualizado = controladorCompromisso.SelecionarPorId(compromisso.Id);
            compromissoAtualizado.Should().Be(novoCompromisso);
        }

        [TestMethod]
        public void DeveNaoEditar_Compromisso_ParaHorarioOcupado()
        {
            //arrange
            var contato = new Contato("José Pedro", "jose.pedro@gmail.com", "321654987", "JP Ltda", "Dev");
            controladorContato.InserirNovo(contato);
            var compromisso = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), contato);
            controladorCompromisso.InserirNovo(compromisso);
            var novoCompromisso = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);

            //action
            string resultado = controladorCompromisso.Editar(compromisso.Id, novoCompromisso);

            //assert
            resultado.Should().Be("Nesta data e horário já existe um compromisso");
            List<Compromisso> compromissos = controladorCompromisso.SelecionarTodos();

            compromissos.Should().HaveCount(1);
        }

        //Excluir
        [TestMethod]
        public void DeveExcluir_Compromisso()
        {
            //arrange
            var contato = new Contato("José Pedro", "jose.pedro@gmail.com", "321654987", "JP Ltda", "Dev");
            controladorContato.InserirNovo(contato);
            var compromisso = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), contato);
            controladorCompromisso.InserirNovo(compromisso);

            //action
            controladorCompromisso.Excluir(compromisso.Id);

            //assert
            var compromissoAtualizado = controladorCompromisso.SelecionarPorId(compromisso.Id);
            compromissoAtualizado.Should().BeNull();
        }

        //Selecionar
        [TestMethod]
        public void DeveSelecionar_TodosCompromissos()
        {
            //arrange
            var c1 = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);
            controladorCompromisso.InserirNovo(c1);

            var c2 = new Compromisso("Assunto Teste", "Restaurante", "discord", new DateTime(2021, 08, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);
            controladorCompromisso.InserirNovo(c2);

            var c3 = new Compromisso("Teste", "uniplac", "skype", new DateTime(2021, 07, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);
            controladorCompromisso.InserirNovo(c3);

            //action
            var compromissos = controladorCompromisso.SelecionarTodos();

            //assert
            compromissos.Should().HaveCount(3);
            compromissos[0].Assunto.Should().Be("Assunto qualquer");
            compromissos[1].Assunto.Should().Be("Assunto Teste");
            compromissos[2].Assunto.Should().Be("Teste");
        }

        [TestMethod]
        public void DeveSelecionar_CompromissosFuturos()
        {
            //arrange
            var c1 = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 09, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);
            controladorCompromisso.InserirNovo(c1);

            var c2 = new Compromisso("Assunto Teste", "Restaurante", "discord", new DateTime(2021, 08, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);
            controladorCompromisso.InserirNovo(c2);

            var c3 = new Compromisso("Teste", "uniplac", "skype", new DateTime(2021, 12, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);
            controladorCompromisso.InserirNovo(c3);

            //action
            var compromissos = controladorCompromisso.SelecionarCompromissosFuturos(DateTime.Today, new DateTime(2022, 08, 12));

            //assert
            compromissos.Should().HaveCount(3);
            compromissos[0].Assunto.Should().Be("Assunto qualquer");
            compromissos[1].Assunto.Should().Be("Assunto Teste");
            compromissos[2].Assunto.Should().Be("Teste");
        }

        [TestMethod]
        public void DeveSelecionar_CompromissosPassados()
        {
            //arrange
            var c1 = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 03, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);
            controladorCompromisso.InserirNovo(c1);

            var c2 = new Compromisso("Assunto Teste", "Restaurante", "discord", new DateTime(2021, 02, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);
            controladorCompromisso.InserirNovo(c2);

            var c3 = new Compromisso("Teste", "uniplac", "skype", new DateTime(2021, 12, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);
            controladorCompromisso.InserirNovo(c3);

            //action
            var compromissos = controladorCompromisso.SelecionarCompromissosPassados(DateTime.Today);

            //assert
            compromissos.Should().HaveCount(2);
            compromissos[0].Assunto.Should().Be("Assunto qualquer");
            compromissos[1].Assunto.Should().Be("Assunto Teste");
        }

        [TestMethod]
        public void DeveSelecionar_Compromisso_PorId()
        {
            //arrange
            var c1 = new Compromisso("Assunto qualquer", "NDD", "Meet.com", new DateTime(2021, 03, 11), new TimeSpan(16, 30, 00), new TimeSpan(17, 30, 00), null);
            controladorCompromisso.InserirNovo(c1);

            //action
            var compromisso = controladorCompromisso.SelecionarPorId(c1.Id);

            //assert
            compromisso.Should().Be(c1);
        }

    }
}
