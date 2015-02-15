using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.enums
{
    public class ApplicationErrorType
    {
        public int code { get; private set; }
        public string message { get; private set; }

        private ApplicationErrorType(int code, string message)
        {
            this.code = code;
            this.message = message;
        }

        /** SUCCESSO */
        public static ApplicationErrorType SUCCESS = new ApplicationErrorType(0, "Successo");

        /** COMMON ERROR 1 - 100 */
        public static ApplicationErrorType FAILURE = new ApplicationErrorType(1, "Fallimento");
        public static ApplicationErrorType NOT_IMPLEMENTED = new ApplicationErrorType(2, "Funzionalità non Implementata");
        public static ApplicationErrorType INVALID_VALUE = new ApplicationErrorType(3, "Valore non Valido");
        public static ApplicationErrorType INVALID_INIT = new ApplicationErrorType(4, "Applicazione non Inizializzata Correttamente");
        public static ApplicationErrorType EMPTY_RESERVED = new ApplicationErrorType(5, "La Riservata non può Essere Nulla o Vuota");
        public static ApplicationErrorType NOT_ALLOWED = new ApplicationErrorType(6, "Operazione non Permessa");
        public static ApplicationErrorType ERROR_RESERVED = new ApplicationErrorType(7, "Errore Riservata");
        public static ApplicationErrorType OPEN_PANEL_ERROR = new ApplicationErrorType(8, "Errore Durante l'Apertura del Pannello");
        public static ApplicationErrorType LOAD_RESERVED_ERROR = new ApplicationErrorType(9, "Errore Durante il Caricamento delle Riservate");
        public static ApplicationErrorType LOAD_STEMMER_ERROR = new ApplicationErrorType(10, "Errore Durante la Lettura delle Parole Stemmate");
        public static ApplicationErrorType INDEXER_INVALID_VALUE = new ApplicationErrorType(11, "Valore non Valido per l'Indicizzazione");
        public static ApplicationErrorType INDEXER_PREPARE_ERROR = new ApplicationErrorType(12, "Problemi Durante l'Indicizzazione");
        public static ApplicationErrorType NO_INDEX = new ApplicationErrorType(13, "Il Valore non può Essere Indicizzato");
        public static ApplicationErrorType WEBSERVICE_ERROR = new ApplicationErrorType(14, "Errore Chiamata Servizio Web");
        public static ApplicationErrorType WEBSERVICE_PARSER_ERROR = new ApplicationErrorType(15, "Errore Risposta del Servizio Web");
        public static ApplicationErrorType OPERATION_ERROR = new ApplicationErrorType(16, "Errore Esecuzione dell'Operazione Richiesta");
        public static ApplicationErrorType READ_RESERVED_ERROR = new ApplicationErrorType(17, "Errore Lettura Parole Riservate");
        public static ApplicationErrorType WRITE_RESERVED_ERROR = new ApplicationErrorType(18, "Errore di Scrittura delle Parole Riservate");
        public static ApplicationErrorType READ_STEMMER_ERROR = new ApplicationErrorType(19, "Errore Lettura Parole Stemmate");
        public static ApplicationErrorType WRITE_STEMMER_ERROR = new ApplicationErrorType(20, "Errore Scrittura Parole Stemmate");
        public static ApplicationErrorType READ_WORD_ERROR = new ApplicationErrorType(21, "Errore Lettura Parole Indicizzate");
        public static ApplicationErrorType WRITE_WORD_ERROR = new ApplicationErrorType(22, "Errore Scrittura Parole Indicizzate");
        public static ApplicationErrorType INVALID_TAB = new ApplicationErrorType(23, "Tab non Riconosciuto");



        /** LIBRARY OPERATION ERROR 101 - 200 */
        public static ApplicationErrorType EMPTY_CATEGORY = new ApplicationErrorType(101, "La Categoria non può Essere Nulla o Vuota");
        public static ApplicationErrorType EMPTY_POSITION = new ApplicationErrorType(102, "La Posizione non può Essere Nulla o Vuota");
        public static ApplicationErrorType CATEGORY_PRESENT = new ApplicationErrorType(103, "Categoria già Presente");
        public static ApplicationErrorType POSITION_PRESENT = new ApplicationErrorType(104, "Posizione già Presente");
        public static ApplicationErrorType EMPTY_FIRSTAME = new ApplicationErrorType(105, "Il Cognome non può Essere Nullo o Vuoto");
        public static ApplicationErrorType AUTHOR_NOT_FOUND = new ApplicationErrorType(106, "Autore non Trovato");
        public static ApplicationErrorType CATEGORY_ERROR = new ApplicationErrorType(107, "Errore Gestione Categorie");
        public static ApplicationErrorType POSITION_ERROR = new ApplicationErrorType(108, "Errore Gestione Posizioni");
        public static ApplicationErrorType EMPTY_TITLE = new ApplicationErrorType(109, "Il Titolo non può Essere Nullo o Vuoto");
        public static ApplicationErrorType NO_ADD_BOOK = new ApplicationErrorType(110, "Impossibile Aggiungere un Nuovo Libro");
        public static ApplicationErrorType BOOK_NOT_FOUND = new ApplicationErrorType(110, "Libro non Trovato");
        public static ApplicationErrorType WRITE_AUTHOR_ERROR = new ApplicationErrorType(110, "Errore Scrittura Autore");
        public static ApplicationErrorType READ_AUTHOR_ERROR = new ApplicationErrorType(111, "Errore Lettura Autore");
        public static ApplicationErrorType WRITE_NOTE_ERROR = new ApplicationErrorType(112, "Errore Scrittura Note Aggiuntive per il Libro");
        public static ApplicationErrorType READ_NOTE_ERROR = new ApplicationErrorType(113, "Errore Lettura Note Aggiuntive per il Libro");
        public static ApplicationErrorType WRITE_W2AUTORE_ERROR = new ApplicationErrorType(116, "Errore Scrittura Parole per Autori");
        public static ApplicationErrorType WRITE_BOOKINFO_ERROR = new ApplicationErrorType(117, "Errore Scrittura Informazioni Aggiuntive per Libro");
        public static ApplicationErrorType READ_BOOKINFO_ERROR = new ApplicationErrorType(118, "Errore Lettura Informazioni Aggiuntive per Libro");
        public static ApplicationErrorType WRITE_BOOK_ERROR = new ApplicationErrorType(119, "Errore Scrittura Libro");
        public static ApplicationErrorType READ_BOOK_ERROR = new ApplicationErrorType(120, "Errore Lettura Libro");
        public static ApplicationErrorType WRITE_W2BOOK_ERROR = new ApplicationErrorType(121, "Errore Scrittura Parole per Libri");
        public static ApplicationErrorType WRITE_CAT_ERROR = new ApplicationErrorType(122, "Errore Scrittura Categoria");
        public static ApplicationErrorType READ_CAT_ERROR = new ApplicationErrorType(123, "Errore Lettura Categorie");
        public static ApplicationErrorType WRITE_POS_ERROR = new ApplicationErrorType(124, "Erorre Scrittura Posizioni");
        public static ApplicationErrorType READ_POS_ERROR = new ApplicationErrorType(125, "Errore Lettura Posizioni");
        public static ApplicationErrorType COUNT_BOOK_ERROR = new ApplicationErrorType(125, "Errore Calcolo Numero di Libri");
        public static ApplicationErrorType COUNT_AUTHOR_ERROR = new ApplicationErrorType(126, "Errore Calcolo Numero di Autori");
        public static ApplicationErrorType NO_AUTHOR_SELECTED = new ApplicationErrorType(127, "Nessun Autore Selezionato");
        public static ApplicationErrorType UPDATE_BOOK_ERROR = new ApplicationErrorType(128, "Modifica Libri Fallita");
        public static ApplicationErrorType DELETE_CATEGORY_ERROR = new ApplicationErrorType(129, "Errore Cancellazione Categoria");
        public static ApplicationErrorType DELETE_AUTHOR_ERROR = new ApplicationErrorType(130, "Errore Cancellazione Autore");
        public static ApplicationErrorType DELETE_WORDMASTER_ERROR = new ApplicationErrorType(131, "Errore Cancellazione Parole");
        public static ApplicationErrorType DELETE_INFOBOOK_ERROR = new ApplicationErrorType(132, "Errore Cancellazione Informazioni Aggiuntive");
        public static ApplicationErrorType DELETE_NOTEBOOK_ERROR = new ApplicationErrorType(133, "Errore Cancellazione Note");
        public static ApplicationErrorType EMPTY_BOOKS = new ApplicationErrorType(133, "Libri non Trovati");
        public static ApplicationErrorType NO_BOOK_SELECTED = new ApplicationErrorType(127, "Nessun Libro Selezionato");


        /** DATABASE ERROR 901 - 920 */
        public static ApplicationErrorType CONNECTION_ERROR = new ApplicationErrorType(901, "Errore di Connessione al Database");

        /** COMMON OPERATION ERROR 921 - 950*/
        public static ApplicationErrorType EMPTY_USERNAME = new ApplicationErrorType(921, "Il Nome Utente non può Essere Nullo o Vuoto");
        public static ApplicationErrorType USER_NOT_FOUND = new ApplicationErrorType(922, "Utente non Trovato");
        public static ApplicationErrorType READ_USER_ERROR = new ApplicationErrorType(923, "Errore Lettura Utente");
        public static ApplicationErrorType WRITE_USER_ERROR = new ApplicationErrorType(924, "Errore Scrittura Utente");


        /** WARNING 1001 */
        public static ApplicationErrorType NOT_INIT_WARN = new ApplicationErrorType(1001, "Warning: Non Inizializzato");
        public static ApplicationErrorType AUTHOR_FIRSTNAME_FOUND_WARN = new ApplicationErrorType(1002, "Warning: Trovati Altri Autori con Lo Stesso Cognome");
        public static ApplicationErrorType AUTHOR_FOUND_WARN = new ApplicationErrorType(1003, "Warning: Trovati Autori Simili o Uguali");
        public static ApplicationErrorType INFOBOOK_NOT_FOUND = new ApplicationErrorType(1004, "Warning: Nessuna Informazione Aggiuntiva Trovata");
        public static ApplicationErrorType TITLE_DIFFERENT_WARN = new ApplicationErrorType(1005, "Warning: I Titolo Sono Differenti. Controllare i Valori");
        public static ApplicationErrorType INFO_DELETE_BYUSER_WARN = new ApplicationErrorType(1006, "Warning: Informazioni Cancellate dall'Utente");
        public static ApplicationErrorType AUTHOR_AMBIG_WARN = new ApplicationErrorType(1007, "Warning: Trovati più Autori");


    }
}
