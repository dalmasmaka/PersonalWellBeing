import { DarkMode } from "@mui/icons-material";
import { AppBar, List, ListItem, Toolbar, Typography } from "@mui/material";
import Switch from "@mui/material/Switch";
import { Box } from "@mui/system";
import { NavLink } from "react-router-dom";
import { useAppSelector } from "../ourApp/configureApp";
import SignedInMenu from "../layout/SignedInMenu";
interface Props{
    darkMode:boolean;
    handleThemeChange: () => void;
}
const rightLinks=[
    {title:'menu', path: '/mainmenu'},
    {title:'team', path: '/members'},
    {title: 'about', path: '/about'},
    {title: 'login', path:'/login'},
    {title: 'register', path:'/register'}
]
const navStyles={
    color:'inherit',
    typography:'h6', 
    '&:hover':{
        color:'grey.500'
    },
    '&.active':{
        color:'text.secondary'
    }
}
export default function Header({darkMode, handleThemeChange}:Props){
    const {user}=useAppSelector(state=>state.account);
    return(
        <AppBar position="static" >
            <Toolbar sx={{display:'flex', justifyContent:'space-between', alignItems:'center'}}>
                <Box sx={{display:'flex', alignItems:'center'}}>
                <Typography variant="h6">
                    PersonalWellBeing
                </Typography>
                <Switch checked={darkMode} onChange={handleThemeChange}/>
                </Box>
                <Box sx={{display:'flex', alignItems:'center'}}>
                    {user?(
                        <SignedInMenu/>
                    ):(
                    <List sx={{display:'flex'}}>
                    {rightLinks.map(({title, path})=>(
                        <ListItem component={NavLink} to={path}
                         key={path}
                         sx={navStyles}
                        >
                        {title.toUpperCase()}
                        </ListItem>
                    ))}
                </List>
                    )}
                </Box>
            </Toolbar>
        </AppBar>
    )
}