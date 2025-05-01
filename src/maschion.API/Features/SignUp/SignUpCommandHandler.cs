using maschion.API.Data;
using maschion.API.Helpers.CQS;
using maschion.API.Infrastructure;

namespace maschion.API.Features.SignUp;

public class SignUpCommandHandler(MaschionDbContext ctx, ISupabaseRepository supabaseRepository) : ICommandAsync<SignUpCommand>
{
    public async Task HandleAsync(SignUpCommand command)
    {
        var supabaseProfile = new SupabaseProfile(command.Email, command.Password);
        var profile = await supabaseRepository.SignUp(supabaseProfile);

        ctx.Profiles.Add(profile);

        ctx.SaveChanges();

        await Task.CompletedTask;
    }
}

