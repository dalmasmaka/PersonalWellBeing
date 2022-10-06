import { AppBar, List, ListItem, Toolbar, Typography } from "@mui/material";
import Switch from "@mui/material/Switch";
import { Box } from "@mui/system";
import { NavLink } from "react-router-dom";
import { useAppSelector } from "../ourApp/configureApp";
import SignedInMenu from "../layout/SignedInMenu";
interface Props {
    darkMode: boolean;
    handleThemeChange: () => void;
}
const leftLinks = [
    { title: 'menu', path: '/mainmenu' },
    { title: 'about', path: '/about' }
]
const rightLinks = [
    { title: 'login', path: '/login' },
    { title: 'register', path: '/register' }
]
const navStyles = {
    color: 'inherit',
    typography: 'h6',
    '&:hover': {
        color: 'grey.500'
    },
    '&.active': {
        color: 'text.inherit'
    }
}
export default function Header({ darkMode, handleThemeChange }: Props) {
    const { user } = useAppSelector(state => state.account);
    return (
        <AppBar position="static" color="inherit">
            <Toolbar sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                <Box sx={{ display: 'flex', alignItems: 'center' }}>

                    {leftLinks.map(({ title, path }) => (

                        <ListItem component={NavLink} to={path}
                            key={path}
                            sx={navStyles}
                        >
                            {title.toUpperCase()}
                        </ListItem>

                    ))}


                    {user && user.roles?.includes('Admin') &&
                        <ListItem component={NavLink} to='/dashboard' sx={navStyles}>DASHBOARD</ListItem>}
                </Box>
                <List sx={{ display: 'flex' }}>
                    <Typography variant="h6" component={NavLink} exact to='/' sx={navStyles}>
                        PersonalWellBeing
                    </Typography>
                    <Switch checked={darkMode} onChange={handleThemeChange} />
                </List>
                {user ? (
                    <SignedInMenu />
                ) : (
                    <List sx={{ display: 'flex' }}>
                        {rightLinks.map(({ title, path }) => (
                            <ListItem component={NavLink} to={path}
                                key={path}
                                sx={navStyles}
                            >
                                {title.toUpperCase()}
                            </ListItem>
                        ))}

                    </List>
                )}
            </Toolbar>
        </AppBar>
    )
}