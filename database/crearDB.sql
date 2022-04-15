DROP TABLE Usuario CASCADE;
CREATE TABLE Usuario(
    email text PRIMARY KEY NOT NULL,
    nombre text NOT NULL,
    apellidos text NOT NULL,
    fNacimiento smallint NOT NULL,
    genero text NOT NULL,
    foto bytea,
    localidad text NOT NULL,
    hashContrasena text NOT NULL,
    meGusta1 text NOT NULL,
    meGusta2 text,
    meGusta3 text,
    noMeGusta1 text NOT NULL,
    noMeGusta2 text,
    noMeGusta3 text
); 

INSERT INTO Usuario VALUES('hola@gmail.com', 'jesus', 'roche', 18, 'm', null, 'Zaragoza', 'contrasena', 'motos', 'coches', 'fulbo', 'tu', 'tu ganga' );

DROP TABLE Mensaje CASCADE;
CREATE TABLE Mensaje(
    mensaje_id SERIAL NOT NULL,
    emisor_id text NOT NULL,
    receptor_id text NOT NULL,
    cuerpo text,
    tStamp timestamp NOT NULL,
    PRIMARY KEY(mensaje_id),
    FOREIGN KEY(emisor_id) REFERENCES Usuario(email),
    FOREIGN KEY(receptor_id) REFERENCES Usuario(email),
    CHECK (emisor_id != receptor_id)
); 

DROP TABLE Plan CASCADE;
CREATE TABLE Plan( 
    plan_id SERIAL NOT NULL,
    lugar text NOT NULL,
    descripcion text NOT NULL,
    predefinido boolean NOT NULL,
    PRIMARY KEY(plan_id)
); 

DROP TABLE Cita CASCADE;
CREATE TABLE Cita(
    cita_id SERIAL NOT NULL,
    usuario1 text NOT NULL,
    usuario2 text NOT NULL,
    plan_id int NOT NULL,
    hora time NOT NULL,
    fecha date NOT NULL,
    PRIMARY KEY(cita_id),
    FOREIGN KEY(usuario1) REFERENCES Usuario(email),
    FOREIGN KEY(usuario2) REFERENCES Usuario(email),
    FOREIGN KEY(plan_id) REFERENCES Plan(plan_id)
);

DROP TABLE Match CASCADE;
CREATE TABLE Match(
    usuario1 text NOT NULL,
    usuario2 text NOT NULL,
    PRIMARY KEY(usuario1, usuario2),
    FOREIGN KEY(usuario1) REFERENCES Usuario(email),
    FOREIGN KEY(usuario2) REFERENCES Usuario(email),
    CHECK (usuario1 != usuario2)
);