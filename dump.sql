--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 16.3

-- Started on 2024-10-07 15:20:03

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 216 (class 1259 OID 24805)
-- Name: task; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.task (
    id integer NOT NULL,
    name text NOT NULL,
    description text,
    fromdate timestamp without time zone NOT NULL,
    todate timestamp without time zone,
    urgency text NOT NULL,
    iscompleted boolean NOT NULL
);


ALTER TABLE public.task OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 24804)
-- Name: task_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.task_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.task_id_seq OWNER TO postgres;

--
-- TOC entry 4787 (class 0 OID 0)
-- Dependencies: 215
-- Name: task_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.task_id_seq OWNED BY public.task.id;


--
-- TOC entry 4634 (class 2604 OID 24808)
-- Name: task id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task ALTER COLUMN id SET DEFAULT nextval('public.task_id_seq'::regclass);


--
-- TOC entry 4781 (class 0 OID 24805)
-- Dependencies: 216
-- Data for Name: task; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.task (id, name, description, fromdate, todate, urgency, iscompleted) FROM stdin;
16	213	213	2024-10-08 00:00:00	2024-10-02 00:00:00	Неотложно	f
1	test	test task	1970-01-01 00:00:00	1970-02-01 00:00:00	Срочно	f
17	выа	ghwdfw	2024-10-08 00:00:00	2024-10-17 00:00:00	Не срочно	t
11	t	t	-infinity	2024-10-23 00:00:00	Срочно	t
\.


--
-- TOC entry 4788 (class 0 OID 0)
-- Dependencies: 215
-- Name: task_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.task_id_seq', 18, true);


--
-- TOC entry 4636 (class 2606 OID 24812)
-- Name: task task_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.task
    ADD CONSTRAINT task_pkey PRIMARY KEY (id);


-- Completed on 2024-10-07 15:20:04

--
-- PostgreSQL database dump complete
--

