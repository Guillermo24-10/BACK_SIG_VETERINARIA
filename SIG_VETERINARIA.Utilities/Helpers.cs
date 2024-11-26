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

        //PATIENT
        public static string SP_LIST_PATIENTS = "SP_LIST_PATIENTS";
        public static string SP_CREATE_PATIENT = "SP_CREATE_PATIENT";
        public static string SP_DELETE_PATIENT = "SP_DELETE_PATIENT";
        public static string SP_GET_PATIENT = "SP_GET_PATIENT";

        //CONSULTS
        public static string SP_LIST_CONSULTS = "SP_LIST_CONSULTS";
        public static string SP_CREATE_CONSULT = "SP_CREATE_CONSULT";
        public static string SP_DELETE_CONSULT = "SP_DELETE_CONSULT";

        //EXAMS
        public static string SP_LIST_EXAMS = "SP_LIST_EXAMS";
        public static string SP_CREATE_EXAMS = "SP_CREATE_EXAMS";
        public static string SP_DELETE_EXAM = "SP_DELETE_EXAM";

        //DIAGNOSTICO
        public static string SP_LIST_DIAGNOSTICOS = "SP_LIST_DIAGNOSTICOS";
        public static string SP_CREATE_DIAGNOSTICO = "SP_CREATE_DIAGNOSTICO";
        public static string SP_DELETE_DIAGNOSTICO = "SP_DELETE_DIAGNOSTICO";

        //CATEGORY
        public static string SP_LIST_CATEGORIES = "SP_LIST_CATEGORIES";
        public static string SP_CREATE_CATEGORY = "SP_CREATE_CATEGORY";
        public static string SP_DELETET_CATEGORY = "SP_DELETET_CATEGORY";

        //PRODUCTS
        public static string SP_LIST_PRODUCTS = "SP_LIST_PRODUCTS";
        public static string SP_CREATE_PRODUCTS = "SP_CREATE_PRODUCTS";
        public static string SP_DELETE_PRODUCT = "SP_DELETE_PRODUCT";
        public static string SP_DETAIL_PRODUCT = "SP_DETAIL_PRODUCT";

        //TRATAMIENTOS
        public static string SP_LIST_TRATAMIENTOS = "SP_LIST_TRATAMIENTOS";
        public static string SP_CREATE_TRATAMIENTO = "SP_CREATE_TRATAMIENTO";
        public static string SP_DELETE_TRATAMIENTO = "SP_DELETE_TRATAMIENTO";

        //PRODUCTS-TRATAMIENTOS
        public static string SP_LIST_PRODUCTS_TRATAMIENTOS = "SP_LIST_PRODUCTS_TRATAMIENTOS";
        public static string SP_CREATE_PRODUCTS_TRATAMIENTOS = "SP_CREATE_PRODUCTS_TRATAMIENTOS";
        public static string SP_DELETE_PRODUCTO_TRATAMIENTO = "SP_DELETE_PRODUCTO_TRATAMIENTO";

    }

    public static class Message
    {
        public static string SAVE = "Se Guardo o Actualizo Correctamente";
        public static string ERROR_SAVE = "No se pudo guardar";
        public static string UPDATE = "Se Actualizó Correctamente";
        public static string DELETE = "Se Eliminó Correctamente";
        public static string ERROR_DELETE = "No se pudo eliminar";
        public const string QUERY = "Consulta exitosa";
        public const string QUERY_EMPTY = "No se encontraron registros";
    }
}
