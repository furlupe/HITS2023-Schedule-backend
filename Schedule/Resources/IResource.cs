using Schedule.Enums;
using Schedule.Models;

namespace Schedule.Resources
{
    public interface IResource
    {
        Task<Teacher> GetTeacher(Guid? id);
        Task<Subject> GetSubject(Guid id);
        Task<Cabinet> GetCabinet(int number);
        Task<Timeslot> GetTimeslot(Guid id);
        Task<ICollection<Group>> GetGroups(ICollection<int> groups);
        Task<ICollection<Lesson>> GetSimilarLessons(Lesson lesson);
        Task<User> GetUserByCredentials(string login, string password);
        Task<bool> IsLoginTaken(string login);
        Task<RefreshToken?> GetRefreshTokenByUser(User user);
        Task<Group?> GetGroup(int? number);
        Task<bool> DoesTeacherAccountExist(Teacher teacher);
        Task<ICollection<Role>> GetRoles(ICollection<RoleEnum> roles);
        Task<RefreshToken> GetRefreshToken(string refreshToken);
        Task AddLesson(Lesson lesson);
        Task ScheduleLesson(LessonScheduled lesson);
        Task AddRefreshToken(RefreshToken refreshToken);
        Task RemoveRefreshToken(RefreshToken refreshToken);
        Task AddBlacklistedToken(BlacklistedToken token);
        Task AddUser(User user);
    }
}
