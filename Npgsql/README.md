## Npgsql
``` sql
ALTER USER postgres WITH PASSWORD 'postgres';
CREATE TABLE public.customer
(
  name text,
  email text,
  phone text,
  address text,
  id serial
)
```