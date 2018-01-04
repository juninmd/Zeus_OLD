using System;
using System.Text;
using Zeus.Core;

namespace Zeus.Frontend.Angular
{
    public class AngularTypeService
    {
        private readonly string _classe;
        private readonly string N = Environment.NewLine;

        public AngularTypeService(string nomeTabela)
        {
            _classe = nomeTabela.TratarNomeTabela().ToLower();
        }

        private StringBuilder GetById()
        {
            var classe = new StringBuilder();
            classe.Append($"        getById: function(id, result) {{ {N}");
            classe.Append($"            $http({{{N}");
            classe.Append($"                method: 'GET', {N}");
            classe.Append($"                 url: urlCore +  \"{_classe}/\" + id, {N}");
            classe.Append($"            }}).then({N}");
            classe.Append($"                function(xhr) {{ {N}");
            classe.Append($"                    result(null, xhr.data.content);{N}");
            classe.Append($"                }},{N}");
            classe.Append($"                function(xhr) {{{N}");
            classe.Append($"                    result(xhr.data, null);{N}");
            classe.Append($"                }});{N}");
            classe.Append($"        }},{N}");
            return classe;
        }

        private StringBuilder Delete()
        {
            var classe = new StringBuilder();
            classe.Append($"        delete: function(id, result) {{ {N}");
            classe.Append($"            $http({{{N}");
            classe.Append($"                method: 'DELETE', {N}");
            classe.Append($"                 url: urlCore +  \"{_classe}/\" + id, {N}");
            classe.Append($"            }}).then({N}");
            classe.Append($"                function(xhr) {{ {N}");
            classe.Append($"                    result(null, xhr.data.content);{N}");
            classe.Append($"                }},{N}");
            classe.Append($"                function(xhr) {{{N}");
            classe.Append($"                    result(xhr.data, null);{N}");
            classe.Append($"                }});{N}");
            classe.Append($"        }},{N}");
            return classe;
        }

        private StringBuilder Get()
        {
            var classe = new StringBuilder();
            classe.Append($"        get: function(result) {{ {N}");
            classe.Append($"            $http({{{N}");
            classe.Append($"                method: 'GET', {N}");
            classe.Append($"                 url: urlCore +  \"{_classe}/\", {N}");
            classe.Append($"            }}).then({N}");
            classe.Append($"                function(xhr) {{ {N}");
            classe.Append($"                    result(null, xhr.data.content);{N}");
            classe.Append($"                }},{N}");
            classe.Append($"                function(xhr) {{{N}");
            classe.Append($"                    result(xhr.data, null);{N}");
            classe.Append($"                }});{N}");
            classe.Append($"        }},{N}");
            return classe;
        }

        private StringBuilder Insert()
        {
            var classe = new StringBuilder();
            classe.Append($"        insert: function(body, result) {{ {N}");
            classe.Append($"            $http({{{N}");
            classe.Append($"                method: 'POST', {N}");
            classe.Append($"                 url: urlCore +  \"{_classe}\",{N}");
            classe.Append($"                 data: body {N}");
            classe.Append($"            }}).then({N}");
            classe.Append($"                function(xhr) {{  {N}");
            classe.Append($"                    result(null, xhr.data.content);{N}");
            classe.Append($"                }},{N}");
            classe.Append($"                function(xhr) {{{N}");
            classe.Append($"                    result(xhr.data, null);{N}");
            classe.Append($"                }});{N}");
            classe.Append($"        }},{N}");
            return classe;
        }

        private StringBuilder Update()
        {
            var classe = new StringBuilder();
            classe.Append($"        update: function(body, result) {{ {N}");
            classe.Append($"            $http({{{N}");
            classe.Append($"                method: 'PUT', {N}");
            classe.Append($"                 url: urlCore +  \"{_classe}/ \", {N}");
            classe.Append($"                 data: body {N}");
            classe.Append($"            }}).then({N}");
            classe.Append($"                function(xhr) {{  {N}");
            classe.Append($"                    result(null, xhr.data.content);{N}");
            classe.Append($"                }},{N}");
            classe.Append($"                function(xhr) {{{N}");
            classe.Append($"                    result(xhr.data, null);{N}");
            classe.Append($"                }});{N}");
            classe.Append($"        }},{N}");
            return classe;
        }

        public StringBuilder GerarClasse()
        {
            var classe = new StringBuilder();
            classe.Append($"angular.module('{_classe}').factory('{_classe}Service', function($http) {{ {N}");
            classe.Append($"    return {{{N}");
            classe.Append(Get());
            classe.Append(GetById());
            classe.Append(Insert());
            classe.Append(Update());
            classe.Append(Delete());
            classe.Append($"    }};{N}");
            classe.Append($"}});");
            return classe;
        }
    }
}