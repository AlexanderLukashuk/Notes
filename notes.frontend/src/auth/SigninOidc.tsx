import { FC, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { signinRedirectCallback } from './user-service';
import React from "react";

const SigninOidc: FC<{}> = () => {
    const navigate = useNavigate();
    useEffect(() => {
        async function signinAsync() {
            await signinRedirectCallback();
            navigate("/");
        }
        signinAsync();
    }, [navigate]);

    return <div>Redirecting...</div>;
};

export default SigninOidc;