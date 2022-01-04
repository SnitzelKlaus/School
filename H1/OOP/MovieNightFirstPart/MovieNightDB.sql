CREATE DATABASE MovieNight;
go
USE MovieNight;
go

CREATE TABLE movie
(
movie_id INT IDENTITY PRIMARY KEY NOT NULL,
movie_title VARCHAR(255) NOT NULL,
movie_year INT NOT NULL,
movie_genre VARCHAR(255) NOT NULL,
movie_description VARCHAR(1024) NOT NULL,
movie_review FLOAT NOT NULL
);

INSERT INTO movie(movie_title, movie_year, movie_genre, movie_description, movie_review) VALUES ('Iron Man', 2008, 'Action', 'When Tony Stark, an industrialist, is captured, he constructs a high-tech armoured suit to escape.', 7.9)
INSERT INTO movie(movie_title, movie_year, movie_genre, movie_description, movie_review) VALUES ('Iron Man 2', 2010, 'Action', 'Tony Stark is under pressure from various sources, including the government, to share his technology with the world.', 7)
INSERT INTO movie(movie_title, movie_year, movie_genre, movie_description, movie_review) VALUES ('Iron Man 3', 2013, 'Action', 'Tony Stark encounters a formidable foe called the Mandarin.', 7.1)
INSERT INTO movie(movie_title, movie_year, movie_genre, movie_description, movie_review) VALUES ('Boss Nigger', 1974, 'Comedy', 'Two black bounty hunters ride into a small town out West in pursuit of an outlaw.', 7.1)
INSERT INTO movie(movie_title, movie_year, movie_genre, movie_description, movie_review) VALUES ('Five Feet Apart', 2019, 'Romance', 'A pair of teenagers with cystic fibrosis meet in a hospital and fall in love', 7.2)
INSERT INTO movie(movie_title, movie_year, movie_genre, movie_description, movie_review) VALUES ('365 Days', 2020, 'Romance', 'Massimo is a member of the Sicilian Mafia family and Laura is a sales director.', 3.2)

CREATE TABLE actor
(
actor_sid INT IDENTITY PRIMARY KEY NOT NULL,
actor_firstname VARCHAR(128) NOT NULL,
actor_lastname VARCHAR(128) NOT NULL
)

INSERT INTO actor(actor_firstname, actor_lastname) VALUES ('Robert', 'Downey, Jr.')
INSERT INTO actor(actor_firstname, actor_lastname) VALUES ('Gwyneth', 'Paltrow')
INSERT INTO actor(actor_firstname, actor_lastname) VALUES ('Ben', 'Kingsley')
INSERT INTO actor(actor_firstname, actor_lastname) VALUES ('Fred', 'Williamson')
INSERT INTO actor(actor_firstname, actor_lastname) VALUES ('Haley', 'Lu Richardson')
INSERT INTO actor(actor_firstname, actor_lastname) VALUES ('Cole', 'Sprouse')
INSERT INTO actor(actor_firstname, actor_lastname) VALUES ('Anna', 'Maria Sieklucka')
INSERT INTO actor(actor_firstname, actor_lastname) VALUES ('Michele', 'Morrone')

CREATE TABLE movie_actor_junction
(
movie_id INT,
actor_sid INT,
CONSTRAINT PK_actor_movie PRIMARY KEY (movie_id, actor_sid),
CONSTRAINT FK_movie FOREIGN KEY (movie_id) REFERENCES movie (movie_id) ON UPDATE CASCADE ON DELETE CASCADE,
CONSTRAINT FK_actor FOREIGN KEY (actor_sid) REFERENCES actor (actor_sid) ON UPDATE CASCADE ON DELETE CASCADE
);

INSERT INTO dbo.movie_actor_junction(movie_id, actor_sid) VALUES (1, 1)
INSERT INTO dbo.movie_actor_junction(movie_id, actor_sid) VALUES (1, 2)
INSERT INTO dbo.movie_actor_junction(movie_id, actor_sid) VALUES (2, 1)
INSERT INTO dbo.movie_actor_junction(movie_id, actor_sid) VALUES (2, 2)
INSERT INTO dbo.movie_actor_junction(movie_id, actor_sid) VALUES (3, 3)
INSERT INTO dbo.movie_actor_junction(movie_id, actor_sid) VALUES (4, 4)
INSERT INTO dbo.movie_actor_junction(movie_id, actor_sid) VALUES (5, 5)
INSERT INTO dbo.movie_actor_junction(movie_id, actor_sid) VALUES (5, 6)
INSERT INTO dbo.movie_actor_junction(movie_id, actor_sid) VALUES (6, 7)
INSERT INTO dbo.movie_actor_junction(movie_id, actor_sid) VALUES (6, 8)