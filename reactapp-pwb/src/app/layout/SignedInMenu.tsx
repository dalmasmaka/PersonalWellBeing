import { Button, Menu, Fade, MenuItem } from "@mui/material";
import React from "react";
 import { signOut } from "../../features/account/accountSlice";
import { useAppDispatch, useAppSelector } from "../ourApp/configureApp";

export default function SignedInMenu() {
    const dispatch = useAppDispatch();
    const { user } = useAppSelector(state => state.account);
    const [anchorEl, setAnchorEl] = React.useState(null);
    const open = Boolean(anchorEl);
    const handleClick = (event: any) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl(null);
    };

    return (
        <>
             <Button
                 color='inherit'
                 onClick={handleClick}
                 sx={{ typography: 'h6' }}
             >
                 {user?.email}
             </Button>
             <Menu
                 anchorEl={anchorEl}
                 open={open}
                 onClose={handleClose}
                 TransitionComponent={Fade}
             >
                 
                 <MenuItem sx={{width:"100%"}} onClick={() => {
                     dispatch(signOut());
                 }}>Logout</MenuItem>
            </Menu>
        </>
    )
}