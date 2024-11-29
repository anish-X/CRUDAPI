namespace CRUDAPI.DTOs
{
    public record UserDto
    (
        int Id,
        string Name,
        string Email,
        string Password,
        string Username
        
    );
}
