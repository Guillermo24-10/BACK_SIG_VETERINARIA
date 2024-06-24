namespace SIG_VETERINARIA.Utilities
{
    public static class Helpers
    {
        public static string SP_LIST_USERS = "SP_LIST_USERS";
        public static string SP_CREATE_USER = "SP_CREATE_USER";
        public static string SP_DELETE_USER = "SP_DELETE_USER";
        public static string SP_GET_USER_BY_USERNAME = "SP_GET_USER_BY_USERNAME";
    }

    public static class Message
    {
        public static string SAVE = "Se Guardo Correctamente";
        public static string ERROR_SAVE = "No se pudo guardar";
        public static string UPDATE = "Se Actualizó Correctamente";
        public static string DELETE = "Se Eliminó Correctamente";
        public static string ERROR_DELETE = "No se pudo eliminar";
        public const string QUERY = "Consulta exitosa";
        public const string QUERY_EMPTY = "No se encontraron registros";
    }
}
