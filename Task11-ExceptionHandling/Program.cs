using Task11_ExceptionHandling;

internal class Program
{
    private static void Main(string[] args)
    {
        UserRegistration registration = new UserRegistration();

        try
        {
            registration.Register("Tariq", "tariq@mail.com", "abc");
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine($"[Age] {ex.Message}");
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"[Validation] {ex.Message}");
            Console.WriteLine($"   Inner: {ex.InnerException?.Message}");

        }
        catch (AppException ex)
        {
            Console.WriteLine($"[App] {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[General] {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Cleanup: registration attempt finished.");
        }
    }
}

