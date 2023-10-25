aplikacja do zarządzania eventami

bazowe założenia:
-rejestracja i logowanie użytkowników do systemu
	walidacja modelu																check

-jeden user może stworzyć event														
-w momencie stworzenia eventu pozostali użytkownicy mają do niego dostęp
-użytkownik wybiera event, podaje hasło jeżeli wymagane i subskrybuje wydarzenie
-użytkownik może wywołać listę i sprawdzić, do jakich wydarzeń jest przypisany
-z poziomu tej listy może odsubskrybować event

dodatkowe targety:
-eventy się przedawniają	
	automatyczne usuwanie po upłynięciu czasu


w jaki sposób keyword event będzie wykorzystywany?:
	-jako system wywołujący zapytania do baz
	-jako tempData dla view?
		jeżeli użytkownik zasubskrybuje event pokaż wiadomość we View
		"Witamy w evencie {event.name}"


