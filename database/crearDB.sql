DROP TABLE Usuario CASCADE;
CREATE TABLE Usuario(
    email text PRIMARY KEY NOT NULL,
    nombre text NOT NULL,
    apellidos text NOT NULL,
    fNacimiento DATE NOT NULL,
    genero text NOT NULL,
    foto bytea,
    localidad text NOT NULL,
    hashContrasena text NOT NULL,
    meGusta1 text NOT NULL,
    meGusta2 text,
    meGusta3 text,
    noMeGusta1 text NOT NULL,
    noMeGusta2 text,
    noMeGusta3 text,
    orientacion text,
    capacidad int
); 

INSERT INTO Usuario VALUES('hola@gmail.com', 'jesus', 'roche', '2004-01-01', 'Hombre', null, 'Zaragoza', 'contrasena', 'motos', 'coches', 'fulbo', 'tu', 'tu ganga', 'test', 'Mujeres', 2 );

DROP TABLE Mensaje CASCADE;
CREATE TABLE Mensaje(
    mensaje_id SERIAL NOT NULL,
    emisor_id text NOT NULL,
    receptor_id text NOT NULL,
    cuerpo text,
    tStamp timestamp NOT NULL,
    PRIMARY KEY(mensaje_id),
    FOREIGN KEY(emisor_id) REFERENCES Usuario(email),
    FOREIGN KEY(receptor_id) REFERENCES Usuario(email) --aqui iria una ,
    -- CHECK (emisor_id != receptor_id)
); 

DROP TABLE Plan CASCADE;
CREATE TABLE Plan( 
    plan_id SERIAL NOT NULL,
    lugar text NOT NULL,
    descripcion text NOT NULL,
    lat double precision NOT NULL,
    lon double precision NOT NULL,
    predefinido boolean NOT NULL,
    PRIMARY KEY(plan_id)
);

INSERT INTO Plan VALUES(DEFAULT,'Picnic en "Parque del Agua"','',-99988.00370824643,5112019.1876577465,true);
INSERT INTO Plan VALUES(DEFAULT,'Cine en "Gran Casa"','',-99009.0268405727,5111481.298800174,true);
INSERT INTO Plan VALUES(DEFAULT,'Correr en "Expo 2008"','',-99648.91451725531,5111124.586965884,true);
INSERT INTO Plan VALUES(DEFAULT,'Tarde de tapas en "El Tubo" ','',-97988.95591933586,5109020.775649178,true);
INSERT INTO Plan VALUES(DEFAULT,'Café en "Starbucks"','',-98212.45198189681,5109171.25818825,true);
INSERT INTO Plan VALUES(DEFAULT,'Partido del Zaragoza en "La Romareda"','',-100388.56390142016,5106646.053773255,true);
INSERT INTO Plan VALUES(DEFAULT,'Paseo en "Parque Grande"','',-99716.69771919289,5106247.205881157,true);
INSERT INTO Plan VALUES(DEFAULT,'Día en "Puerto Venecia"','',-98849.38535177145,5102574.082900999,true);
INSERT INTO Plan VALUES(DEFAULT,'Jarras en "100 Montaditos"','',-98958.28926077537,5111776.574086482,true);
INSERT INTO Plan VALUES(DEFAULT,'Croquetas en "Croquet Arte"','',-98373.68131975929,5109257.062187031,true);
INSERT INTO Plan VALUES(DEFAULT,'Concierto en "Pabellón Príncipe Felipe"','',-96436.33110060728,5106530.842877436,true);
INSERT INTO Plan VALUES(DEFAULT,'Cervezas en "La City"','',-99835.02767577293,5107347.850332098,true);

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