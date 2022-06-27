namespace Authentication.Repo;

public interface IAuthAction<TEntity> where TEntity : AuthModel
{
    bool IsValid(AuthModel credential);
}
