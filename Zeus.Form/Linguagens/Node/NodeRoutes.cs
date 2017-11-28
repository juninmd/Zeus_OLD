using System;
using System.Text;
using Zeus.Core;

namespace Zeus.Linguagens.Node
{
    public class NodeRoutes
    {
        private readonly string _classe;
        private readonly string N = Environment.NewLine;

        public NodeRoutes(string nomeTabela)
        {
            this._classe = nomeTabela.TratarNomeTabela().ToLower();
        }

        public StringBuilder GerarClasse()
        {
            var classe = new StringBuilder();
            classe.Append($"var {_classe} = requireController(\"{_classe}\");{N}");
            classe.Append($"app.route(`/{_classe}/:id`).get({_classe}.getById);;{N}");
            classe.Append($"app.route(`/{_classe}/`).get({_classe}.getAll);{N}");
            classe.Append($"app.route(`/{_classe}/`).post({_classe}.insert);{N}");
            classe.Append($"app.route(`/{_classe}/`).put({_classe}.update);{N}");
            classe.Append($"app.route(`/{_classe}/:id`).delete({_classe}.delete);{N}");
            return classe;
        }
    }
}
