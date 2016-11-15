using System;
using System.Text;
using MapeadorDeEntidades.Form.Core;

namespace MapeadorDeEntidades.Form.Linguagens.Node
{
    public class NodeController
    {
        private readonly string _classe;
        private readonly string N = Environment.NewLine;

        public NodeController(string nomeTabela)
        {
            this._classe = nomeTabela.TratarNomeTabela().ToLower();
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"var {_classe} = require('../repository/{_classe}Repository.js');{N}{N}");
            return imports;
        }

        private StringBuilder GetById()
        {
            var get = new StringBuilder();
            get.Append($"    getById: function (req, res) {{{N}");
            get.Append($"        {_classe}.getById(req.query, function (err, result) {{{N}");
            get.Append($"            if (err) {{{N}");
            get.Append($"                res.status(err.statusCode).send(err);{N}");
            get.Append($"            }} else {{  {N}");
            get.Append($"                res.status(200).send(result);{N}");
            get.Append($"            }};{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder GetAll()
        {
            var get = new StringBuilder();
            get.Append($"    getAll: function (req, res) {{{N}");
            get.Append($"        {_classe}.getAll(function (err, result) {{{N}");
            get.Append($"            if (err) {{{N}");
            get.Append($"                res.status(err.statusCode).send(err);{N}");
            get.Append($"            }} else {{  {N}");
            get.Append($"                res.status(200).send(result);{N}");
            get.Append($"            }};{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Add()
        {
            var get = new StringBuilder();
            get.Append($"    insert: function (req, res) {{{N}");
            get.Append($"        {_classe}.insert(req.body, function (err, result) {{{N}");
            get.Append($"            if (err) {{{N}");
            get.Append($"                res.status(err.statusCode).send(err);{N}");
            get.Append($"            }} else {{  {N}");
            get.Append($"                res.status(200).send(result);{N}");
            get.Append($"            }};{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Update()
        {

            var get = new StringBuilder();
            get.Append($"    update: function (req, res) {{{N}");
            get.Append($"        {_classe}.update(req.body, function (err, result) {{{N}");
            get.Append($"            if (err) {{{N}");
            get.Append($"                res.status(err.statusCode).send(err);{N}");
            get.Append($"            }} else {{  {N}");
            get.Append($"                res.status(200).send(result);{N}");
            get.Append($"            }};{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }
        private StringBuilder Delete()
        {
            var get = new StringBuilder();
            get.Append($"    delete: function (req, res) {{{N}");
            get.Append($"        {_classe}.delete(req.query, function (err, result) {{{N}");
            get.Append($"            if (err) {{{N}");
            get.Append($"                res.status(err.statusCode).send(err);{N}");
            get.Append($"            }} else {{  {N}");
            get.Append($"                res.status(200).send(result);{N}");
            get.Append($"            }};{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        public StringBuilder GerarClasse()
        {
            var classe = new StringBuilder();
            classe.Append(Imports());
            classe.Append($"module.exports = {{{N}");
            classe.Append(GetById());
            classe.Append(GetAll());
            classe.Append(Add());
            classe.Append(Update());
            classe.Append(Delete());
            classe.Append($"}};{N}");
            return classe;
        }
    }
}
