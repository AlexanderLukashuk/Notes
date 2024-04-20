import React, { useEffect } from "react";
import { FC } from "react";
import { useNavigate } from "react-router-dom";
import { signinRedirectCallback } from './user-service';

const SignoutOidc: FC<{}> = () => {
    const navigate = useNavigate();
    useEffect(() => {
        const signoutAsync = async () => {
            await signinRedirectCallback();
            navigate('/');
        };
        signoutAsync();
    }, [navigate]);
    return <div>Redirecting...</div>
};

export default SignoutOidc;