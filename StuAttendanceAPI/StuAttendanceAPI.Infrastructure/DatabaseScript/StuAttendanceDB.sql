PGDMP                      |            TapIn    16.4    17.1 P    _           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            `           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            a           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            b           1262    16388    TapIn    DATABASE     o   CREATE DATABASE "TapIn" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'C.UTF-8';
    DROP DATABASE "TapIn";
                     postgres    false                        3079    16389 	   uuid-ossp 	   EXTENSION     ?   CREATE EXTENSION IF NOT EXISTS "uuid-ossp" WITH SCHEMA public;
    DROP EXTENSION "uuid-ossp";
                        false            c           0    0    EXTENSION "uuid-ossp"    COMMENT     W   COMMENT ON EXTENSION "uuid-ossp" IS 'generate universally unique identifiers (UUIDs)';
                             false    2            �            1255    16400    delete_admin(uuid) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_admin(IN p_adminid uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM public.admins
    WHERE adminid = p_adminid;
END;
$$;
 7   DROP PROCEDURE public.delete_admin(IN p_adminid uuid);
       public               postgres    false            �            1255    16401    delete_attendance_record(uuid) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_attendance_record(IN aid uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM AttendanceRecords WHERE AttendanceId = aid;
END;
$$;
 =   DROP PROCEDURE public.delete_attendance_record(IN aid uuid);
       public               postgres    false            �            1255    16402 1   delete_attendance_record_by_ids(uuid, uuid, uuid) 	   PROCEDURE     D  CREATE PROCEDURE public.delete_attendance_record_by_ids(IN p_attendance_id uuid, IN p_student_id uuid, IN p_session_id uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM public.attendancerecords
    WHERE attendanceid = p_attendance_id
      AND studentid = p_student_id
      AND sessionid = p_session_id;
END;
$$;
 |   DROP PROCEDURE public.delete_attendance_record_by_ids(IN p_attendance_id uuid, IN p_student_id uuid, IN p_session_id uuid);
       public               postgres    false            �            1255    16403 0   delete_attendance_record_for_student(uuid, uuid) 	   PROCEDURE       CREATE PROCEDURE public.delete_attendance_record_for_student(IN p_student_id uuid, IN p_session_id uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM public.attendancerecords
    WHERE studentid = p_student_id
    AND sessionid = p_session_id;
END;
$$;
 h   DROP PROCEDURE public.delete_attendance_record_for_student(IN p_student_id uuid, IN p_session_id uuid);
       public               postgres    false            �            1255    16404    delete_course(uuid) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_course(IN cid uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM Courses WHERE CourseId = cid;
END;
$$;
 2   DROP PROCEDURE public.delete_course(IN cid uuid);
       public               postgres    false            �            1255    16405    delete_session(uuid) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_session(IN sid uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM Sessions WHERE SessionId = sid;
END;
$$;
 3   DROP PROCEDURE public.delete_session(IN sid uuid);
       public               postgres    false            �            1255    16406    delete_student(uuid) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_student(IN p_studentid uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM public.students
    WHERE studentid = p_studentid;
END;
$$;
 ;   DROP PROCEDURE public.delete_student(IN p_studentid uuid);
       public               postgres    false            �            1255    16407    delete_teacher(uuid) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_teacher(IN p_teacherid uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM public.teachers
    WHERE teacherid = p_teacherid;
END;
$$;
 ;   DROP PROCEDURE public.delete_teacher(IN p_teacherid uuid);
       public               postgres    false            �            1255    16408    delete_user(uuid) 	   PROCEDURE     �   CREATE PROCEDURE public.delete_user(IN uid uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM Users WHERE UserId = uid;
END;
$$;
 0   DROP PROCEDURE public.delete_user(IN uid uuid);
       public               postgres    false            �            1255    16409    get_all_sessions()    FUNCTION     �  CREATE FUNCTION public.get_all_sessions() RETURNS TABLE(session_id uuid, course_id uuid, session_date date, start_at time without time zone, end_at time without time zone, session_name character varying, total_duration interval)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        s.sessionid,
        s.courseid,
        s.date,
        s.startat,
        s.endat,
        s.name,
        s.totalduration
    FROM
        public.sessions s;
END;
$$;
 )   DROP FUNCTION public.get_all_sessions();
       public               postgres    false            �            1255    16410     get_attendance_for_session(uuid)    FUNCTION     �  CREATE FUNCTION public.get_attendance_for_session(session_id uuid) RETURNS TABLE(attendance_id uuid, student_id uuid, sign_in_at timestamp without time zone, sign_out_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        a.AttendanceId, 
        a.StudentId, 
        a.SignInAt, 
        a.SignOutAt
    FROM AttendanceRecords a
    WHERE a.SessionId = session_id;
END;
$$;
 B   DROP FUNCTION public.get_attendance_for_session(session_id uuid);
       public               postgres    false            �            1255    16411 2   get_attendance_for_session_and_student(uuid, uuid)    FUNCTION     �  CREATE FUNCTION public.get_attendance_for_session_and_student(p_session_id uuid, p_student_id uuid) RETURNS TABLE(attendance_id uuid, student_id uuid, sign_in_at timestamp without time zone, sign_out_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        a.AttendanceId, 
        a.StudentId, 
        a.SignInAt, 
        a.SignOutAt
    FROM AttendanceRecords a
    WHERE a.SessionId = p_session_id
      AND a.StudentId = p_student_id;
END;
$$;
 c   DROP FUNCTION public.get_attendance_for_session_and_student(p_session_id uuid, p_student_id uuid);
       public               postgres    false            �            1255    16412    get_course_by_id(uuid)    FUNCTION     �  CREATE FUNCTION public.get_course_by_id(p_course_id uuid) RETURNS TABLE(course_id uuid, course_name character varying, teacher_id uuid, created_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT c.CourseId, c.CourseName, c.TeacherId, c.CreatedAt
    FROM Courses AS c
    WHERE c.CourseId = p_course_id;  -- Use the updated parameter name
END;
$$;
 9   DROP FUNCTION public.get_course_by_id(p_course_id uuid);
       public               postgres    false            �            1255    16413 %   get_course_by_name(character varying)    FUNCTION     _  CREATE FUNCTION public.get_course_by_name(course_name character varying) RETURNS TABLE(course_id uuid, teacher_id uuid, created_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        c.CourseId, 
        c.TeacherId, 
        c.CreatedAt
    FROM Courses c
    WHERE c.CourseName = course_name;
END;
$$;
 H   DROP FUNCTION public.get_course_by_name(course_name character varying);
       public               postgres    false            �            1255    16414    get_courses_by_teacher_id(uuid)    FUNCTION     �  CREATE FUNCTION public.get_courses_by_teacher_id(p_teacherid uuid) RETURNS TABLE(course_id uuid, course_name character varying, created_at timestamp without time zone, teacher_id uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        c.courseid,
        c.coursename,
        c.createdat,
        c.teacherid  -- Include teacherid here
    FROM
        public.courses c
    WHERE
        c.teacherid = p_teacherid;
END;
$$;
 B   DROP FUNCTION public.get_courses_by_teacher_id(p_teacherid uuid);
       public               postgres    false            �            1255    16415 .   get_courses_by_teacher_name(character varying)    FUNCTION     �  CREATE FUNCTION public.get_courses_by_teacher_name(teacher_name character varying) RETURNS TABLE(course_id uuid, course_name character varying, teacher_id uuid, created_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY 
    SELECT c.CourseId, c.CourseName, c.TeacherId, c.CreatedAt
    FROM Courses c
    JOIN Teachers t ON c.TeacherId = t.TeacherId
    JOIN Users u ON t.UserId = u.UserId
    WHERE CONCAT(u.FirstName, ' ', u.LastName) = teacher_name;
END;
$$;
 R   DROP FUNCTION public.get_courses_by_teacher_name(teacher_name character varying);
       public               postgres    false            �            1255    16416    get_session_by_id(uuid)    FUNCTION       CREATE FUNCTION public.get_session_by_id(p_session_id uuid) RETURNS TABLE(session_id uuid, course_id uuid, session_date date, start_at time without time zone, end_at time without time zone, session_name character varying, total_duration interval)
    LANGUAGE plpgsql ROWS 1
    AS $$
BEGIN
    RETURN QUERY SELECT 
        s.sessionid, 
        s.courseid, 
        s.date, 
        s.startat, 
        s.endat, 
        s.name, 
        s.totalduration
    FROM public.sessions s
    WHERE s.sessionid = p_session_id;
END;
$$;
 ;   DROP FUNCTION public.get_session_by_id(p_session_id uuid);
       public               postgres    false                       1255    16417    get_session_details_by_id(uuid)    FUNCTION     �  CREATE FUNCTION public.get_session_details_by_id(input_session_id uuid) RETURNS TABLE(session_id uuid, session_name character varying, session_date date, start_time time without time zone, end_time time without time zone, total_duration interval, course_id uuid, course_name character varying, teacher_id uuid, teacher_first_name character varying, teacher_last_name character varying, teacher_email character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        s.sessionid,
        s.name,
        s.date,
        s.startat,
        s.endat,
        s.totalduration,
        c.courseid,
        c.coursename,
        u.userid,
        u.firstname,
        u.lastname,
        u.email
    FROM 
        public.sessions s
    JOIN 
        public.courses c ON s.courseid = c.courseid
    JOIN 
        public.users u ON u.userid = c.teacherid
    WHERE 
        s.sessionid = input_session_id;
END;
$$;
 G   DROP FUNCTION public.get_session_details_by_id(input_session_id uuid);
       public               postgres    false                       1255    16532    get_sessions_for_course(uuid)    FUNCTION     ]  CREATE FUNCTION public.get_sessions_for_course(input_course_id uuid) RETURNS TABLE(session_id uuid, session_name character varying, session_date date, start_time time without time zone, end_time time without time zone, total_duration interval, course_id uuid, course_name character varying, teacher_id uuid, teacher_first_name character varying, teacher_last_name character varying, teacher_email character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        s.SessionId, 
        s.Name as SessionName,
        s.Date as SessionDate, 
        s.StartAt as StartTime, 
        s.EndAt as EndTime, 
        s.TotalDuration, 
        c.CourseId as CourseId,  -- Ensure alias doesn't clash
        c.CourseName, 
        t.TeacherId, 
        u.FirstName as TeacherFirstName, 
        u.LastName as TeacherLastName, 
        u.Email as TeacherEmail
    FROM Sessions s
    JOIN Courses c ON s.CourseId = c.CourseId
    JOIN Teachers t ON c.TeacherId = t.TeacherId
    JOIN Users u ON t.UserId = u.UserId
    WHERE s.CourseId = input_course_id;  -- Use the changed parameter name here
END;
$$;
 D   DROP FUNCTION public.get_sessions_for_course(input_course_id uuid);
       public               postgres    false                       1255    16419    get_student_by_id(uuid)    FUNCTION       CREATE FUNCTION public.get_student_by_id(sid uuid) RETURNS TABLE(user_id uuid, student_group character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        s.UserId, 
        s.StudentGroup
    FROM Students s
    WHERE s.StudentId = sid;
END;
$$;
 2   DROP FUNCTION public.get_student_by_id(sid uuid);
       public               postgres    false                       1255    16420    get_students_for_course(uuid)    FUNCTION     �  CREATE FUNCTION public.get_students_for_course(course_id uuid) RETURNS TABLE(user_id uuid, first_name character varying, last_name character varying, email character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT u.UserId, u.FirstName, u.LastName, u.Email
    FROM Users u
    JOIN Students s ON u.UserId = s.UserId
    JOIN AttendanceRecords ar ON s.StudentId = ar.StudentId
    JOIN Sessions ses ON ar.SessionId = ses.SessionId
    WHERE ses.CourseId = course_id;
END;
$$;
 >   DROP FUNCTION public.get_students_for_course(course_id uuid);
       public               postgres    false                       1255    16421 &   get_teacher_courses_and_sessions(uuid)    FUNCTION       CREATE FUNCTION public.get_teacher_courses_and_sessions(teacher_id uuid) RETURNS TABLE(course_id uuid, course_name character varying, session_id uuid, session_date date, start_at time without time zone, end_at time without time zone, session_name character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT c.CourseId, c.CourseName, s.SessionId, s.Date, s.StartAt, s.EndAt, s.Name
    FROM Courses c
    JOIN Sessions s ON c.CourseId = s.CourseId
    WHERE c.TeacherId = teacher_id;
END;
$$;
 H   DROP FUNCTION public.get_teacher_courses_and_sessions(teacher_id uuid);
       public               postgres    false                       1255    16422 $   get_user_by_email(character varying)    FUNCTION     �  CREATE FUNCTION public.get_user_by_email(user_email character varying) RETURNS TABLE(user_id uuid, first_name character varying, last_name character varying, role character varying, avatar_url character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        u.UserId, 
        u.FirstName, 
        u.LastName, 
        u.Role, 
        u.AvatarUrl
    FROM Users u
    WHERE u.Email = user_email;
END;
$$;
 F   DROP FUNCTION public.get_user_by_email(user_email character varying);
       public               postgres    false                       1255    16423    get_user_by_id(uuid)    FUNCTION     �  CREATE FUNCTION public.get_user_by_id(uid uuid) RETURNS TABLE(user_id uuid, first_name character varying, last_name character varying, email character varying, role character varying, avatar_url character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        u.UserId,       
        u.FirstName, 
        u.LastName, 
        u.Email, 
        u.Role, 
        u.AvatarUrl
    FROM Users u
    WHERE u.UserId = uid;
END;
$$;
 /   DROP FUNCTION public.get_user_by_id(uid uuid);
       public               postgres    false                       1255    16424 '   get_user_by_password(character varying)    FUNCTION     �  CREATE FUNCTION public.get_user_by_password(user_password character varying) RETURNS TABLE(user_id uuid, first_name character varying, last_name character varying, role character varying, avatar_url character varying, email character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT u.UserId, u.FirstName, u.LastName, u.Role, u.AvatarUrl, u.Email
    FROM Users AS u
    WHERE u.Password = user_password;
END;
$$;
 L   DROP FUNCTION public.get_user_by_password(user_password character varying);
       public               postgres    false                       1255    16425 #   get_user_by_role(character varying)    FUNCTION     �  CREATE FUNCTION public.get_user_by_role(user_role character varying) RETURNS TABLE(user_id uuid, first_name character varying, last_name character varying, email character varying, avatar_url character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        u.UserId, 
        u.FirstName, 
        u.LastName, 
        u.Email, 
        u.AvatarUrl
    FROM Users u
    WHERE u.Role = user_role;
END;
$$;
 D   DROP FUNCTION public.get_user_by_role(user_role character varying);
       public               postgres    false                       1255    16426    insert_admin(uuid) 	   PROCEDURE     �   CREATE PROCEDURE public.insert_admin(IN p_userid uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO public.admins (userid)
    VALUES (p_userid);
END;
$$;
 6   DROP PROCEDURE public.insert_admin(IN p_userid uuid);
       public               postgres    false                       1255    16427 d   insert_attendance_record(uuid, uuid, uuid, timestamp without time zone, timestamp without time zone) 	   PROCEDURE     �  CREATE PROCEDURE public.insert_attendance_record(IN attendance_id uuid, IN session_id uuid, IN student_id uuid, IN sign_in_at timestamp without time zone, IN sign_out_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO AttendanceRecords (AttendanceId, SessionId, StudentId, SignInAt, SignOutAt)
    VALUES (attendance_id, session_id, student_id, sign_in_at, sign_out_at);
END;
$$;
 �   DROP PROCEDURE public.insert_attendance_record(IN attendance_id uuid, IN session_id uuid, IN student_id uuid, IN sign_in_at timestamp without time zone, IN sign_out_at timestamp without time zone);
       public               postgres    false                       1255    16428 I   insert_course(uuid, character varying, uuid, timestamp without time zone) 	   PROCEDURE     J  CREATE PROCEDURE public.insert_course(IN course_id uuid, IN course_name character varying, IN teacher_id uuid, IN created_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO Courses (CourseId, CourseName, TeacherId, CreatedAt)
    VALUES (course_id, course_name, teacher_id, created_at);
END;
$$;
 �   DROP PROCEDURE public.insert_course(IN course_id uuid, IN course_name character varying, IN teacher_id uuid, IN created_at timestamp without time zone);
       public               postgres    false                       1255    16429 m   insert_session(uuid, uuid, date, time without time zone, time without time zone, character varying, interval) 	   PROCEDURE     �  CREATE PROCEDURE public.insert_session(IN session_id uuid, IN course_id uuid, IN session_date date, IN start_at time without time zone, IN end_at time without time zone, IN name character varying, IN total_duration interval)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO Sessions (SessionId, CourseId, Date, StartAt, EndAt, Name, TotalDuration)
    VALUES (session_id, course_id, session_date, start_at, end_at, name, total_duration);
END;
$$;
 �   DROP PROCEDURE public.insert_session(IN session_id uuid, IN course_id uuid, IN session_date date, IN start_at time without time zone, IN end_at time without time zone, IN name character varying, IN total_duration interval);
       public               postgres    false                       1255    16528 X   insert_session(uuid, uuid, timestamp with time zone, interval, interval, text, interval) 	   PROCEDURE     �  CREATE PROCEDURE public.insert_session(IN session_id uuid, IN course_id uuid, IN session_date timestamp with time zone, IN start_at interval, IN end_at interval, IN name text, IN total_duration interval)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO Sessions (SessionId, CourseId, Date, StartAt, EndAt, Name, TotalDuration)
    VALUES (session_id, course_id, session_date, start_at, end_at, name, total_duration);
END;
$$;
 �   DROP PROCEDURE public.insert_session(IN session_id uuid, IN course_id uuid, IN session_date timestamp with time zone, IN start_at interval, IN end_at interval, IN name text, IN total_duration interval);
       public               postgres    false            �            1255    16527 �   insert_session(uuid, uuid, timestamp with time zone, time without time zone, time without time zone, character varying, interval) 	   PROCEDURE     �  CREATE PROCEDURE public.insert_session(IN session_id uuid, IN course_id uuid, IN session_date timestamp with time zone, IN start_at time without time zone, IN end_at time without time zone, IN name character varying, IN total_duration interval)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO Sessions (SessionId, CourseId, Date, StartAt, EndAt, Name, TotalDuration)
    VALUES (session_id, course_id, session_date::date, start_at, end_at, name, total_duration);
END;
$$;
 �   DROP PROCEDURE public.insert_session(IN session_id uuid, IN course_id uuid, IN session_date timestamp with time zone, IN start_at time without time zone, IN end_at time without time zone, IN name character varying, IN total_duration interval);
       public               postgres    false                       1255    16430 '   insert_student(uuid, character varying) 	   PROCEDURE     �   CREATE PROCEDURE public.insert_student(IN p_userid uuid, IN p_studentgroup character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO public.students (studentid, userid, studentgroup)
    VALUES (p_userid, p_userid, p_studentgroup);
END;
$$;
 ]   DROP PROCEDURE public.insert_student(IN p_userid uuid, IN p_studentgroup character varying);
       public               postgres    false            �            1255    16431 '   insert_teacher(uuid, character varying) 	   PROCEDURE     �   CREATE PROCEDURE public.insert_teacher(IN p_userid uuid, IN p_department character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO public.teachers (teacherid, userid, department)
    VALUES (p_userid, p_userid, p_department);
END;
$$;
 [   DROP PROCEDURE public.insert_teacher(IN p_userid uuid, IN p_department character varying);
       public               postgres    false            �            1255    16432 �   insert_user(uuid, character varying, character varying, character varying, character varying, character varying, timestamp without time zone, character varying) 	   PROCEDURE     �  CREATE PROCEDURE public.insert_user(IN user_id uuid, IN fname character varying, IN lname character varying, IN email character varying, IN role character varying, IN avatar_url character varying, IN created_at timestamp without time zone, IN user_password character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO Users (UserId, FirstName, LastName, Email, Role, AvatarUrl, CreatedAt, Password)
    VALUES (user_id, fname, lname, email, role, avatar_url, created_at, user_password);
END;
$$;
   DROP PROCEDURE public.insert_user(IN user_id uuid, IN fname character varying, IN lname character varying, IN email character varying, IN role character varying, IN avatar_url character varying, IN created_at timestamp without time zone, IN user_password character varying);
       public               postgres    false            �            1255    16433    update_admin(uuid, uuid) 	   PROCEDURE     �   CREATE PROCEDURE public.update_admin(IN p_adminid uuid, IN p_userid uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE public.admins
    SET
        userid = p_userid
    WHERE
        adminid = p_adminid;
END;
$$;
 I   DROP PROCEDURE public.update_admin(IN p_adminid uuid, IN p_userid uuid);
       public               postgres    false            �            1255    16434 X   update_attendance_record(uuid, timestamp without time zone, timestamp without time zone) 	   PROCEDURE     =  CREATE PROCEDURE public.update_attendance_record(IN aid uuid, IN sign_in_at timestamp without time zone, IN sign_out_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE AttendanceRecords
    SET SignInAt = sign_in_at,
        SignOutAt = sign_out_at
    WHERE AttendanceId = aid;
END;
$$;
 �   DROP PROCEDURE public.update_attendance_record(IN aid uuid, IN sign_in_at timestamp without time zone, IN sign_out_at timestamp without time zone);
       public               postgres    false            �            1255    16435 I   update_course(uuid, character varying, uuid, timestamp without time zone) 	   PROCEDURE     P  CREATE PROCEDURE public.update_course(IN cid uuid, IN course_name character varying, IN teacher_id uuid, IN created_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE Courses
    SET CourseName = course_name,
        TeacherId = teacher_id,
        CreatedAt = created_at
    WHERE CourseId = cid;
END;
$$;
 �   DROP PROCEDURE public.update_course(IN cid uuid, IN course_name character varying, IN teacher_id uuid, IN created_at timestamp without time zone);
       public               postgres    false                       1255    16436 m   update_session(uuid, uuid, date, time without time zone, time without time zone, character varying, interval) 	   PROCEDURE     �  CREATE PROCEDURE public.update_session(IN sid uuid, IN course_id uuid, IN session_date date, IN start_at time without time zone, IN end_at time without time zone, IN name character varying, IN total_duration interval)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE Sessions
    SET CourseId = course_id,
        Date = session_date,
        StartAt = start_at,
        EndAt = end_at,
        Name = name,
        TotalDuration = total_duration
    WHERE SessionId = sid;
END;
$$;
 �   DROP PROCEDURE public.update_session(IN sid uuid, IN course_id uuid, IN session_date date, IN start_at time without time zone, IN end_at time without time zone, IN name character varying, IN total_duration interval);
       public               postgres    false                       1255    16437 -   update_student(uuid, uuid, character varying) 	   PROCEDURE     0  CREATE PROCEDURE public.update_student(IN p_studentid uuid, IN p_userid uuid, IN p_studentgroup character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE public.students
    SET
        userid = p_userid,
        studentgroup = p_studentgroup
    WHERE
        studentid = p_studentid;
END;
$$;
 r   DROP PROCEDURE public.update_student(IN p_studentid uuid, IN p_userid uuid, IN p_studentgroup character varying);
       public               postgres    false                       1255    16438 -   update_teacher(uuid, uuid, character varying) 	   PROCEDURE     *  CREATE PROCEDURE public.update_teacher(IN p_teacherid uuid, IN p_userid uuid, IN p_department character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE public.teachers
    SET
        userid = p_userid,
        department = p_department
    WHERE
        teacherid = p_teacherid;
END;
$$;
 p   DROP PROCEDURE public.update_teacher(IN p_teacherid uuid, IN p_userid uuid, IN p_department character varying);
       public               postgres    false                       1255    16439 p   update_user(uuid, character varying, character varying, character varying, character varying, character varying) 	   PROCEDURE     �  CREATE PROCEDURE public.update_user(IN uid uuid, IN fname character varying, IN lname character varying, IN email character varying, IN role character varying, IN avatar_url character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE Users
    SET FirstName = fname,
        LastName = lname,
        Email = email,
        Role = role,
        AvatarUrl = avatar_url
    WHERE UserId = uid;
END;
$$;
 �   DROP PROCEDURE public.update_user(IN uid uuid, IN fname character varying, IN lname character varying, IN email character varying, IN role character varying, IN avatar_url character varying);
       public               postgres    false            �            1259    16440    admins    TABLE     m   CREATE TABLE public.admins (
    adminid uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    userid uuid
);
    DROP TABLE public.admins;
       public         heap r       postgres    false    2            �            1259    16444    attendancerecords    TABLE     �   CREATE TABLE public.attendancerecords (
    attendanceid uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    sessionid uuid,
    studentid uuid,
    signinat timestamp without time zone,
    signoutat timestamp without time zone
);
 %   DROP TABLE public.attendancerecords;
       public         heap r       postgres    false    2            �            1259    16448    courses    TABLE     �   CREATE TABLE public.courses (
    courseid uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    coursename character varying(100),
    teacherid uuid,
    createdat timestamp without time zone
);
    DROP TABLE public.courses;
       public         heap r       postgres    false    2            �            1259    16452    sessions    TABLE       CREATE TABLE public.sessions (
    sessionid uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    courseid uuid,
    date date,
    startat time without time zone,
    endat time without time zone,
    name character varying(100),
    totalduration interval
);
    DROP TABLE public.sessions;
       public         heap r       postgres    false    2            �            1259    16456    students    TABLE     �   CREATE TABLE public.students (
    studentid uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    userid uuid,
    studentgroup character varying(100)
);
    DROP TABLE public.students;
       public         heap r       postgres    false    2            �            1259    16460    teachers    TABLE     �   CREATE TABLE public.teachers (
    teacherid uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    userid uuid,
    department character varying(100)
);
    DROP TABLE public.teachers;
       public         heap r       postgres    false    2            �            1259    16464    users    TABLE     Z  CREATE TABLE public.users (
    userid uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    firstname character varying(50),
    lastname character varying(50),
    email character varying(100),
    role character varying(20),
    avatarurl character varying(255),
    createdat timestamp without time zone,
    password character varying(50)
);
    DROP TABLE public.users;
       public         heap r       postgres    false    2            V          0    16440    admins 
   TABLE DATA           1   COPY public.admins (adminid, userid) FROM stdin;
    public               postgres    false    216   �       W          0    16444    attendancerecords 
   TABLE DATA           d   COPY public.attendancerecords (attendanceid, sessionid, studentid, signinat, signoutat) FROM stdin;
    public               postgres    false    217   4�       X          0    16448    courses 
   TABLE DATA           M   COPY public.courses (courseid, coursename, teacherid, createdat) FROM stdin;
    public               postgres    false    218   Q�       Y          0    16452    sessions 
   TABLE DATA           b   COPY public.sessions (sessionid, courseid, date, startat, endat, name, totalduration) FROM stdin;
    public               postgres    false    219   �       Z          0    16456    students 
   TABLE DATA           C   COPY public.students (studentid, userid, studentgroup) FROM stdin;
    public               postgres    false    220   �       [          0    16460    teachers 
   TABLE DATA           A   COPY public.teachers (teacherid, userid, department) FROM stdin;
    public               postgres    false    221   :�       \          0    16464    users 
   TABLE DATA           i   COPY public.users (userid, firstname, lastname, email, role, avatarurl, createdat, password) FROM stdin;
    public               postgres    false    222   ��       �           2606    16471    admins admins_pkey 
   CONSTRAINT     U   ALTER TABLE ONLY public.admins
    ADD CONSTRAINT admins_pkey PRIMARY KEY (adminid);
 <   ALTER TABLE ONLY public.admins DROP CONSTRAINT admins_pkey;
       public                 postgres    false    216            �           2606    16473    admins admins_userid_key 
   CONSTRAINT     U   ALTER TABLE ONLY public.admins
    ADD CONSTRAINT admins_userid_key UNIQUE (userid);
 B   ALTER TABLE ONLY public.admins DROP CONSTRAINT admins_userid_key;
       public                 postgres    false    216            �           2606    16475 (   attendancerecords attendancerecords_pkey 
   CONSTRAINT     p   ALTER TABLE ONLY public.attendancerecords
    ADD CONSTRAINT attendancerecords_pkey PRIMARY KEY (attendanceid);
 R   ALTER TABLE ONLY public.attendancerecords DROP CONSTRAINT attendancerecords_pkey;
       public                 postgres    false    217            �           2606    16477    courses courses_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.courses
    ADD CONSTRAINT courses_pkey PRIMARY KEY (courseid);
 >   ALTER TABLE ONLY public.courses DROP CONSTRAINT courses_pkey;
       public                 postgres    false    218            �           2606    16479    sessions sessions_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY public.sessions
    ADD CONSTRAINT sessions_pkey PRIMARY KEY (sessionid);
 @   ALTER TABLE ONLY public.sessions DROP CONSTRAINT sessions_pkey;
       public                 postgres    false    219            �           2606    16481    students students_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_pkey PRIMARY KEY (studentid);
 @   ALTER TABLE ONLY public.students DROP CONSTRAINT students_pkey;
       public                 postgres    false    220            �           2606    16483    students students_userid_key 
   CONSTRAINT     Y   ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_userid_key UNIQUE (userid);
 F   ALTER TABLE ONLY public.students DROP CONSTRAINT students_userid_key;
       public                 postgres    false    220            �           2606    16485    teachers teachers_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY public.teachers
    ADD CONSTRAINT teachers_pkey PRIMARY KEY (teacherid);
 @   ALTER TABLE ONLY public.teachers DROP CONSTRAINT teachers_pkey;
       public                 postgres    false    221            �           2606    16487    teachers teachers_userid_key 
   CONSTRAINT     Y   ALTER TABLE ONLY public.teachers
    ADD CONSTRAINT teachers_userid_key UNIQUE (userid);
 F   ALTER TABLE ONLY public.teachers DROP CONSTRAINT teachers_userid_key;
       public                 postgres    false    221            �           2606    16489    users users_email_key 
   CONSTRAINT     Q   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_key UNIQUE (email);
 ?   ALTER TABLE ONLY public.users DROP CONSTRAINT users_email_key;
       public                 postgres    false    222            �           2606    16491    users users_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (userid);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public                 postgres    false    222            �           2606    16492    admins admins_userid_fkey    FK CONSTRAINT     {   ALTER TABLE ONLY public.admins
    ADD CONSTRAINT admins_userid_fkey FOREIGN KEY (userid) REFERENCES public.users(userid);
 C   ALTER TABLE ONLY public.admins DROP CONSTRAINT admins_userid_fkey;
       public               postgres    false    4287    216    222            �           2606    16497 2   attendancerecords attendancerecords_sessionid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.attendancerecords
    ADD CONSTRAINT attendancerecords_sessionid_fkey FOREIGN KEY (sessionid) REFERENCES public.sessions(sessionid);
 \   ALTER TABLE ONLY public.attendancerecords DROP CONSTRAINT attendancerecords_sessionid_fkey;
       public               postgres    false    4275    219    217            �           2606    16502 2   attendancerecords attendancerecords_studentid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.attendancerecords
    ADD CONSTRAINT attendancerecords_studentid_fkey FOREIGN KEY (studentid) REFERENCES public.students(studentid);
 \   ALTER TABLE ONLY public.attendancerecords DROP CONSTRAINT attendancerecords_studentid_fkey;
       public               postgres    false    217    4277    220            �           2606    16507    courses courses_teacherid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.courses
    ADD CONSTRAINT courses_teacherid_fkey FOREIGN KEY (teacherid) REFERENCES public.teachers(teacherid);
 H   ALTER TABLE ONLY public.courses DROP CONSTRAINT courses_teacherid_fkey;
       public               postgres    false    218    221    4281            �           2606    16512    sessions sessions_courseid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.sessions
    ADD CONSTRAINT sessions_courseid_fkey FOREIGN KEY (courseid) REFERENCES public.courses(courseid);
 I   ALTER TABLE ONLY public.sessions DROP CONSTRAINT sessions_courseid_fkey;
       public               postgres    false    218    219    4273            �           2606    16517    students students_userid_fkey    FK CONSTRAINT        ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_userid_fkey FOREIGN KEY (userid) REFERENCES public.users(userid);
 G   ALTER TABLE ONLY public.students DROP CONSTRAINT students_userid_fkey;
       public               postgres    false    4287    220    222            �           2606    16522    teachers teachers_userid_fkey    FK CONSTRAINT        ALTER TABLE ONLY public.teachers
    ADD CONSTRAINT teachers_userid_fkey FOREIGN KEY (userid) REFERENCES public.users(userid);
 G   ALTER TABLE ONLY public.teachers DROP CONSTRAINT teachers_userid_fkey;
       public               postgres    false    222    221    4287            V      x������ � �      W      x������ � �      X   �  x���;�1D��S���O"չ{'��gXL�3����m8q�6A	롪��s�/��YϏ�~]�FV�\� �Pl(���5�-��@�.�{�t�T�e� �6�;v��A �:K���"�*&x�ES�&>,C���V����=�;��UМԑr�~X��ȿP��]t��aB��:���L�Z��+d�ժQ��˗���|�.��_�^�(mJ����.!Agj�en��D:,7�ї��g���׸?/#��=� .;��|Cʲ��W	�H���
�� |h��yy�~���?�t���0��C���41���N.�;�v3U�kE�$P��n0�N��z�JGk��y�x�g�M`�Yv�挴~��u���P      Y     x����NC1��s��ȱ��aCb��E����f�$����W�V���I��W���5��	�!�G0FAXJ�S��;7��@�8O�7虝�P��:���Q�󷈣&��|o?����OH�ٜ���S��d�#Bi=�+b�T�b��2GF��˸T8���k���c&�T�W�gx�.��nv����`UG��ծ��Q4^�WNy�-������q�4�?f
9�xD:rTo�"v�l�7�%p������w��Z�]�}7;˹����2Z������N�R���z�l����f��?cь�      Z     x���;ND1E�d��$v~-t��&�1�b
@h�OF��I.�����}9H!*#�Uh�L����P���0%P��=�($=g!_ߟ��8��`T*[��4XK���-tb�.�:��6���������0��KKVx���7;L0ɨ���'�l�tNX�8P�
�wL�c[*�5K8��ޏ��J��Iq�@cu�,�)!6���痋kT^)��.By/����U�&�Z�p
�u9�n���d�M��P���{(���j�k8]��qķ��/�      [   G  x�����U!Ek�W�q $��V�Z�$!�y��7�������i�b1ٛ�Ml�
MbE�0��h#�EqX�26.	0�����as]�)Y~�?������q�1����s�m���4�4dz���{'$-��И����.|�����9��g�Z��"�>rnݖ��-蟐�ж�ԁ�����$�Z�-�vvK��;���3CÑ+�R2)����0���� ���`�-9��(���_��}��
\-N����I�
ִY��,��O?���z��/񒯑o�ꜧP���"X���3�SŒ�-�?�{�ن�rn9�_�ؠ��'F��t"�����Nţ      \   A  x��WYs�~v~�@�%Q��NK $a�5/����&,�~��s{��f�D��9�b*��X����ʑb�"&�Fs��6�翼�˝�y�qQ?#\���d�𚢄)
�^�ה��b��\;���H���`>]��o�IW5�Y�'AjBp��y9cyl1��#��%��(�y��D��r����b!����0ǐ��)�G�&%2Q&$��?]OR�[��TM1��v�����VY�5_vW���藷V�Ό�w���j#ڸ[�./M�#��xb�E�ŞQ�����/��6����qS��4~4�m�iz=�#��M���������UU �رl�./��T�D��Bǁ��3�p̵�V�X$�b�2|����P5"�*��Zv�� s������MK�}<;h�R��p�.|={���ڨ��Q�5��%$�("6q�<(�st�נX����X1.y�����2n.g�c[�xtڊ׍��>=���t����nxy!(,��<	�Na��z�$��%�h��Ajެ��b��z�2��ǙZ���7�����4�r�4�?��B4�X��fR�2Z�����^�Ү��|7��q��v��k�q��y=c�]��+΂@.v	�3�Il��	�9V$Ĭ�V~�����_G��)�ܬ��q{��m��밑�/`)n`��ƤR����~w�f�]o Z�Ѥ����i(�k�u�2�IU^�T�1�H[�'�"������]T��4�?[��.�� �2?�j,f6=:�����~����=?L�3���j���{b���Xｼ���'0 ��&NYE��p�Jg��>�O	��H5�Q"9���x�ه|��ʒ���}�:ޓ4��z��c���g��@AƁ:iA�cRn82�8�@����S���@��{��Ah`~tu�p<ݼ�Fnr���j�ٮZ�7�au�ʯ;�a�V./K-�#���p	}T	 f��b$R|Z�������Dc�����4P���W���G��]��kK��k�ntg�y%񰹼����\�Q���x���ȳث����sD��&A>T#�M����cX��]��K���x.�S�v;�^N��Bbk�yEV�'�& �^K�$�-�V���.���xH��Ҫ�R�5�<$/Ǚ�����y��n��i����᪃����Q�xzy�-T�8�,� 	��h� �=q��HB�2Wd�┥��Ϫ�>4���SA8'�r��'	{j�K�v���������ݖ��w�i1z_�Xc �43���*�#L���;��FF�)=�eݛ�!/*i�YpjV�S]������$��+#W&]�|_�_�Ufd<�������a呉70�xF!@�L���������(]�.s����²H]~�s������@DcG��0E�����r���l�j���̛��^�͞��k����EgS� �QjcdP�+<K�E2a�c�bk]��K�G�������J��e6��ר �PR���gd���{�r���V3&X�?�N�֡�/{�j�]=Ln��gT���C�2��)6���"�w1�����vY��J�E%?T2SYDi��<}R(�09SCp�����h��-���6Yeoד���O�夣�����rY-��S0ڎZG`P�@�`��ł� �R��?��?���Ӣ��=�C����3R&j��1䛗lٓe��fuP�Jw��#�v�ѸX��s�����tʜRB#�!�C7H��{�0��G��"�n6>������o������P}d��׈P��e6�v��uk�U�i{��.�F�!:t�>�_������T"� !�C�g��`ǐjP��|PZ/~E�{���� �δ�ѡ����fv�?����(��ͩ�9|�,Ugo�#>R��=�S�@p*Q�r9|�'"ZdY���=Y�-��p ��9ɟӲ�q�*:
w��aJ䘲��l=W�K`�z*�j����5��|~�qbm��*	uJ ��(��2�Sk��%��t[��������<���	���5�v�^��� @4�w��y]��	�o��y���>��ݸZ����j�o//��]\\�	1�     