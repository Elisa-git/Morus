using Application.Interfaces;
using Application.NovaPasta1;
using AutoMapper;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Validacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly INotificador _notificador;
        private readonly IUsuario _usuarioRepository;
        private readonly ValidatorBase<Usuario> _usuarioValidation;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICondominio _condominioRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UsuarioApplication(INotificador notificador,
                                  IUsuario usuarioRepository,
                                  RoleManager<IdentityRole> roleManager,
                                  UserManager<User> userManager,
                                  SignInManager<User> signInManager,
                                  IHttpContextAccessor httpContextAccessor,
                                  ICondominio condominioRepository,
                                  IMapper mapper)
        {
            _notificador = notificador;
            _usuarioRepository = usuarioRepository;
            _usuarioValidation = new ValidatorBase<Usuario>(notificador);
            _signInManager = signInManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _condominioRepository = condominioRepository;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task Cadastrar(Usuario usuario)
        {
            if (!_usuarioValidation.ValidarEntidade(usuario))
                throw new ValidacaoException();

            await _usuarioRepository.Add(usuario);
        }

        public async Task<bool> CadastrarMorador(User userIdentity, Usuario usuarioSistema)
        {
            var idUsuarioLogado = _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type.Equals("idUsuario", StringComparison.InvariantCultureIgnoreCase))?.Value;
            usuarioSistema.Id_condominio = (await _usuarioRepository.ListarMessage(w => w.IdUserIdentity.Equals(idUsuarioLogado)))?.FirstOrDefault()?.Id_condominio;

            var user = await _userManager.FindByEmailAsync(userIdentity.Email);
            if (user != null)
                throw new RegisterException("Erro: Email já cadastrado");

            if (!_usuarioValidation.ValidarEntidade(usuarioSistema))
                throw new ValidacaoException();

            if (!await _roleManager.RoleExistsAsync("Morador"))
                throw new RegisterException("Erro: Tipo de usuário inexistente");

            if (!(await _userManager.CreateAsync(userIdentity)).Succeeded)
            {
                _notificador.Notificar($"Falha ao cadastrar usuário.");
                throw new ApplicationException();
            }
            var usuarioCriado = await _userManager.FindByEmailAsync(userIdentity.Email);
            usuarioSistema.IdUserIdentity = usuarioCriado.Id;

            if (!(await _userManager.AddToRoleAsync(usuarioCriado, "Morador")).Succeeded)
            {
                _notificador.Notificar("Erro: Falha ao definir tipo do usuário.");
                throw new ApplicationException();
            }

            await _usuarioRepository.Add(usuarioSistema);

            return true;
        }

        public async Task<UsuarioLoginResponse> ObterDadosUsuarioLogin(string idUsuarioIdentity)
        {
            var usuarioLogin = (await _usuarioRepository.ListarMessageIncludeCondominio(w => w.IdUserIdentity == idUsuarioIdentity))?.FirstOrDefault();

            return new UsuarioLoginResponse { Usuario = _mapper.Map<UsuarioLogadoResponse>(usuarioLogin) };
        }
    }
}
