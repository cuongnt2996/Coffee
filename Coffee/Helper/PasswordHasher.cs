using BCrypt.Net;

public static class PasswordHasher
{
    // WorkFactor (cost): 10-12 là hợp lý cho server bình thường.
    // Tăng số này => an toàn hơn nhưng tốn CPU hơn.
    private static int WorkFactor => 12; // bạn có thể cấu hình qua appsettings nếu muốn

    /// <summary>
    /// Hash mật khẩu (tự sinh salt).
    /// </summary>
    public static string Hash(string plainPassword)
    {
        if (string.IsNullOrWhiteSpace(plainPassword))
            throw new ArgumentException("Password cannot be empty.", nameof(plainPassword));

        // BCrypt sẽ tự generate salt, kèm work factor
        return BCrypt.Net.BCrypt.HashPassword(plainPassword, WorkFactor);
    }

    /// <summary>
    /// Verify mật khẩu plain với hash lưu trong DB.
    /// </summary>
    public static bool Verify(string plainPassword, string hashedPassword)
    {
        if (string.IsNullOrEmpty(hashedPassword))
            return false;

        return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
    }

    /// <summary>
    /// Kiểm tra xem hash có cần rehash (ví dụ khi tăng work factor).
    /// Trả về true nếu cần re-hash password và lưu lại phiên bản mới.
    /// </summary>
    public static bool NeedsRehash(string hashedPassword)
    {
        if (string.IsNullOrEmpty(hashedPassword)) return false;
        return BCrypt.Net.BCrypt.PasswordNeedsRehash(hashedPassword, WorkFactor);
    }
}
