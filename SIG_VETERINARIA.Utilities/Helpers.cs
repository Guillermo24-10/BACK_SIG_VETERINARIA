namespace SIG_VETERINARIA.Utilities
{
    public static class Helpers
    {
        //USER
        public static string SP_LIST_USERS = "SP_LIST_USERS";
        public static string SP_CREATE_USER = "SP_CREATE_USER";
        public static string SP_DELETE_USER = "SP_DELETE_USER";
        public static string SP_GET_USER_BY_USERNAME = "SP_GET_USER_BY_USERNAME";

        //SPECIE
        public static string SP_LIST_SPECIES = "SP_LIST_SPECIES";
        public static string SP_CREATE_SPECIE = "SP_CREATE_SPECIE";
        public static string SP_DELETE_SPECIE = "SP_DELETE_SPECIE";

        //BREED
        public static string SP_LIST_BREEDS = "SP_LIST_BREEDS";
        public static string SP_CREATE_BREED = "SP_CREATE_BREED";
        public static string SP_DELETE_BREED = "SP_DELETE_BREED";

        //CLIENT
        public static string SP_LIST_CLIENTS = "SP_LIST_CLIENTS";
        public static string SP_CREATE_CLIENTS = "SP_CREATE_CLIENTS";
        public static string SP_DELETE_CLIENT = "SP_DELETE_CLIENT";
        public static string SP_GET_CLIENT = "SP_GET_CLIENT";
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
